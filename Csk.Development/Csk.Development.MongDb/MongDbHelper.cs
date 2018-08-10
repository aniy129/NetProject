using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Csk.Development.MongDb
{
    public class MongDbHelper<T> where T : MongdbBaseEntity, new()
    {
        private static readonly string connCtionStr = "mongodb://192.168.142.133:27017?maxPoolSize=100;minPoolSize=10;waitQueueTimeoutMS=300000";

        private static readonly string dataBase = "cskTest";
        public static ObjectId InsertOne(T t)
        {
            IMongoCollection<T> collection = GetCollection();
            collection.InsertOne(t);
            return t.Id;
        }

        public static async Task<ObjectId> InsertOneAsync(T t)
        {
            IMongoCollection<T> collection = GetCollection();
            await collection.InsertOneAsync(t);
            return t.Id;
        }

        /// <summary>
        /// 创建索引
        /// </summary>
        /// <param name="key"></param>
        public static void CreateIndex(string key)
        {
            IMongoCollection<T> collection = GetCollection();
            var keys = Builders<T>.IndexKeys.Ascending(key);
            collection.Indexes.CreateOneAsync(keys);
        }
        public static void InsertOneAsync1(T t)
        {
            IMongoCollection<T> collection = GetCollection();
            collection.InsertOneAsync(t);
        }
        private static IMongoCollection<T> GetCollection()
        {
            var client = new MongoClient(connCtionStr);
            var database = client.GetDatabase(dataBase);
            IMongoCollection<T> collection = database.GetCollection<T>(typeof(T).Name);
            return collection;
        }

        public static IQueryable<T> QueryEntiy<s>(Expression<Func<T, bool>> filter, Expression<Func<T, s>> orderby, int skip, int count)
        {
            IMongoCollection<T> collection = GetCollection();
            var rs = collection.AsQueryable().Where(filter).OrderBy<T, s>(orderby).Skip(skip).Take(count);
            return rs;
        }
        public static bool Update(T t)
        {
            IMongoCollection<T> collection = GetCollection();
            UpdateDefinition<T> update = null;
            foreach (var item in t.GetType().GetProperties())
            {
                if (item.Name != "Id")
                {
                    update = Builders<T>.Update.Set(item.Name, item.GetValue(t));
                }
            }
            var rs = collection.UpdateOne<T>(c => c.Id == t.Id, update, new UpdateOptions() { IsUpsert = true });
            return rs.ModifiedCount > 0;
        }
        public static bool Delete(T t)
        {
            IMongoCollection<T> collection = GetCollection();
            var rs = collection.DeleteOne<T>(c => c.Id == t.Id);
            return rs.DeletedCount > 0;
        }
    }
}
