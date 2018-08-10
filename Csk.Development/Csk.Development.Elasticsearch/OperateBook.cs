using GateWay.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csk.Development.Elasticsearch
{
    public class OperateBook
    {
        private static ElasticClient GetClient()
        {
            var node = new Uri("http://192.168.40.75:9200");
            var settings = new ConnectionSettings(node).DefaultIndex("orders2017");
            var client = new ElasticClient(settings);
            return client;
        }

        public void AddBook(Book book)
        {
            var client = GetClient();
            client.Index<Book>(book);
        }
       
        public List<Book> Search(Func<SearchDescriptor<Book>, ISearchRequest> selector, out ISearchResponse<Book> doc)
        {
            var client = GetClient();
            var rs = client.Search<Book>(selector);
            doc = rs;
            return rs.Documents.ToList();
        }

        public void Createindex()
        {
            var client = GetClient();
            var rs = client.CreateIndex("orders2017", mp => mp.Mappings(m => m.Map<ESOrder>(ma => ma.AutoMap())));

        }
        public void IsTypeExists()
        {
            var client = GetClient();
            var rs = client.TypeExists("mybook", typeof(Book));
        }
    }
}
