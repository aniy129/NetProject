using StackExchange.Redis;
using System;
using System.Diagnostics;
using System.IO;

namespace Csk.Development.RedisMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer Instance = ConnectionMultiplexer.Connect("192.168.142.130:6379");
            var dt = Instance.GetDatabase();
            dt.SetAdd("yes", "sdsds");

            ISubscriber sub = Instance.GetSubscriber();
            // var rs1 = sub.Publish("p-asa", "支付中心压力测试，测试编号：");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 20; i++)
            {
                var rs = sub.Publish("all", Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    occur = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    content = Newtonsoft.Json.JsonConvert.SerializeObject(new { text = "无类型测试：" + i, id = i })
                }));
            }
            stopwatch.Stop();
            System.Console.WriteLine("总共耗时：" + stopwatch.ElapsedMilliseconds + "毫秒");
            Console.ReadKey();
            
            var fileName = Path.GetFileName(path: "1212");
        }
    }
}
