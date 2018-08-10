using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Csk.Development.MongDb
{
    class Program
    {
        static void Main(string[] args)
        {

            // var dt = MongDbHelper<Entity>.InsertOne(new Entity() { Name = "测试哈" });
            string name = "同步写入";
            var s = MongDbHelper<Entity>.QueryEntiy(c => c.Name.Contains(name), x => x.Id, 0, 100).FirstOrDefault();
            //s.Name = "我的修改";
            //bool fl = MongDbHelper<Entity>.Update(s);

           // MongDbHelper<Entity>.CreateIndex("Name");
            Stopwatch st = new Stopwatch();
            st.Start();
            for (int i = 0; i < 10000; i++)
            {
                var dt = MongDbHelper<Entity>.InsertOne(new Entity() { Name = "同步写入" });
            }
            st.Stop();
            Console.WriteLine("同步写入时间:{0}", st.ElapsedMilliseconds);
            st.Reset();
            st.Start();
            for (int i = 0; i < 10000; i++)
            {
                var dt = MongDbHelper<Entity>.InsertOneAsync(new Entity() { Name = "异步可等待写入" });
            }
            st.Stop();
            Console.WriteLine("异步可等待写入时间:{0}", st.ElapsedMilliseconds);
            st.Reset();
            st.Start();
            for (int i = 0; i < 10000; i++)
            {
                MongDbHelper<Entity>.InsertOneAsync1(new Entity() { Name = "异步写入" });
            }
            Console.WriteLine("异步写入时间:{0}", st.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
    public class Entity : MongdbBaseEntity
    {

        public string Name { get; set; }
    }

    public class Entity2
    {
        public ObjectId Id { get; set; }
        public string Test { get; set; }
        public int Age { get; set; }

    }
}
