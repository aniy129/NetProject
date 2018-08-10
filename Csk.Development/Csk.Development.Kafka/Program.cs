using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Csk.Development.Kafka
{

    public class Program
    {
        public static void Main(string[] args)
        {

            //if (args.Length != 2)
            //{
            //    Console.WriteLine("Usage:  AdvancedProducer brokerList topicName");
            //    return;
            //}

            string brokerList = "hadoop-1:9092";
            string topicName = "meminfo";

            /*
            // TODO(mhowlett): allow partitioner to be set.
            var topicConfig = new TopicConfig
            {
                CustomPartitioner = (top, key, cnt) =>
                {
                    var kt = (key != null) ? Encoding.UTF8.GetString(key, 0, key.Length) : "(null)";
                    int partition = (key?.Length ?? 0) % cnt;
                    bool available = top.PartitionAvailable(partition);
                    Console.WriteLine($"Partitioner topic: {top.Name} key: {kt} partition count: {cnt} -> {partition} {available}");
                    return partition;
                }
            };
            */

            var config = new Dictionary<string, object> { { "bootstrap.servers", brokerList } };

            using (var producer = new Producer<string, string>(config, new StringSerializer(Encoding.UTF8), new StringSerializer(Encoding.UTF8)))
            {
                Console.WriteLine("\n-----------------------------------------------------------------------");
                Console.WriteLine($"Producer {producer.Name} producing on topic {topicName}.");
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("To create a kafka message with UTF-8 encoded key/value message:");
                Console.WriteLine("> key value<Enter>");
                Console.WriteLine("To create a kafka message with empty key and UTF-8 encoded value:");
                Console.WriteLine("> value<enter>");
                Console.WriteLine("Ctrl-C to quit.\n");

                var cancelled = false;
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cancelled = true;
                };

                while (!cancelled)
                {
                    Console.Write("> ");

                    string text;
                    try
                    {
                        text = Console.ReadLine();
                    }
                    catch (IOException)
                    {
                        // IO exception is thrown when ConsoleCancelEventArgs.Cancel == true.
                        break;
                    }
                    if (text == null)
                    {
                        // Console returned null before 
                        // the CancelKeyPress was treated
                        break;
                    }

                    var key = "";
                    var val = text;

                    // split line if both key and value specified.
                    var index = text.IndexOf(" ", StringComparison.Ordinal);
                    if (index != -1)
                    {
                        key = text.Substring(0, index);
                        val = text.Substring(index + 1);
                    }

                    var deliveryReport = producer.ProduceAsync(topicName, key, val);
                    var result = deliveryReport.Result; // synchronously waits for message to be produced.
                    Console.WriteLine($"Partition: {result.Partition}, Offset: {result.Offset}");
                }
            }
        }
    }

}
