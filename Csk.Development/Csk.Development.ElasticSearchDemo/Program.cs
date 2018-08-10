using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Csk.Development.ElasticSearchDemo
{
    [ElasticsearchType(IdProperty = "Id", Name = "Index")]
    public class Index
    {
        public Int64 Id { get; set; }
        [Nest.Text(Analyzer = "ik_max_word")]
        public string FirstName { get; set; }
        [Nest.Text(Analyzer = "ik_max_word")]
        public string LastName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var client = GetClient();


            //多条件搜索and 用&& or用 || 
            var rs = client.Search<Index>(q => q
                                                 .Query(x => x
                                                  .Match(m => m
                                                               .Field(i => i.FirstName)
                                                               .Query("钱钟书")
                                                               // .Operator(Operator.And)
                                                               // .MinimumShouldMatch(new MinimumShouldMatch (2))
                                                               //.Boost(2)
                                                              // .Analyzer("ik_max_word")
                                                               )
                                                   || x
                                                   .Match(m => m
                                                               .Field(ff => ff.LastName)
                                                               .Query("香港")
                                                               )
                                                   ).Highlight(c => c.Fields(x => x.Field(v => v.LastName)))
                                                   );
            //获取结果
            var ls = rs.Documents.ToList<Index>();

            //must 相当于（）同时满足多个条件
            var rs3 = client.Search<Index>(c => c.Query(q => q
                                                          .Bool(b => b.Must(m => m.Match(
                                                                f => f.Field(fl => fl.LastName)
                                                                   .Query("偶买噶44")
                                                                ), m => m.Match(
                                                                     f => f.Field(fl => fl.FirstName)
                                                                     .Query("测试344"))

                                                              ))

                                                            ));
            var ls3 = rs3.Documents.ToList<Index>();

            var searchRequest = new SearchRequest<Index>();
            MatchQuery mq = new MatchQuery();
            mq.Field = Infer.Field<Index>(f => f.FirstName);
            mq.Query = "我的es";
            searchRequest.Query = mq;


            //var ss = client.Search<Index>(searchRequest);
            var ss = client.Search<Index>(q => q.Query(r => r.MatchPhrase(c => c.Query("哈").Field(x => x.LastName))).AllTypes().Highlight(c => c.Fields(xx => xx.Field(xxx => xxx.LastName))));
            var ls4 = ss.Documents.ToList<Index>();

            var index2 = new Index()
            {
                LastName = "哈哈哈",
                FirstName = "我的es"
            };
            var condition = QueryCondition(index2);
            var s5 = client.Search<Index>(condition);
            var l5 = s5.Documents.ToList();
            var s6 = client.Search<Index>(q => q.Query(f => f.ConstantScore(s => s.Filter(fl => fl.Range(r => r.Field(d => d.Id).GreaterThan(2).LessThan(100))))));
            //ik分词器的使用
            var s7 = client.Analyze(c => c.Analyzer("ik_max_word").Text(new string[] { "今天天气真是好啊" }));

            var s8 = client.Analyze(c => c.Analyzer("pinyin").Text(new string[] { "重复的岁月，没落的年华" }));

        }

        public static ElasticClient GetClient()
        {
            var node = new Uri("http://192.168.142.130:9200");
            var settings = new ConnectionSettings(node).DefaultIndex("myindex");
            var client = new ElasticClient(settings);
            return client;
        }
        /// <summary>
        /// 单个添加或更新
        /// </summary>
        /// <param name="index"></param>
        public static void AddOrUpdateSingelModel(Index index)
        {
            GetClient().Index<Index>(index);
        }
        /// <summary>
        /// 批量添加或更新
        /// </summary>
        /// <param name="list"></param>
        public static void AddOrUpdateListModel(List<Index> list)
        {
            GetClient().IndexMany<Index>(list);
        }
        /// <summary>
        /// 多条件拼接
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Func<SearchDescriptor<Index>, ISearchRequest> QueryCondition(Index index)
        {
            Func<SearchDescriptor<Index>, ISearchRequest> result;
            List<Func<QueryContainerDescriptor<Index>, QueryContainer>> querys = new List<Func<QueryContainerDescriptor<Index>, QueryContainer>>();
            if (!string.IsNullOrWhiteSpace(index.FirstName))
            {
                querys.Add(o => o.Match(m => m.Field(c => c.FirstName).Query(index.FirstName)));
            }
            if (!string.IsNullOrWhiteSpace(index.LastName))
            {
                querys.Add(o => o.Match(m => m.Field(c => c.LastName).Query(index.LastName)) && o.Match(m => m.Field(c => c.Id).Query("2")));
            }
            Func<QueryContainerDescriptor<Index>, QueryContainer> condition =
               o => o.Bool(b => b.Must(
                querys.ToArray()
                ));
            Expression<Func<Index, object>> fl = o => o.Id;
            result = o => o.Query(condition).Sort(c => c.Descending(Infer.Field<Index>(fl)));
            return result;
        }
        public static object GetStr(Index x)
        {
            return x.Id;
        }
    }
}
