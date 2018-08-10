using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Csk.Development.RabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                SendMsg(i + "其实我很在乎你，是否你能也明白……");

            }

            // var msg = ReceiveMsg();

        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        private static void SendMsg(string msg)
        {
            var model = GetChannel();
            // model.ExchangeDeclare("exchange", ExchangeType.Direct);
            model.QueueDeclare("myquen4", true, false, false, null);
            // model.QueueBind("myquen2", "exchange", "", null);
            byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(msg);
            IBasicProperties props = model.CreateBasicProperties();
            props.Persistent = true;
            model.BasicPublish("", "myquen4", props, messageBodyBytes);
        }
        /// <summary>
        /// 接受消息
        /// </summary>
        /// <returns></returns>
        private static string ReceiveMsg()
        {
            var model = GetChannel();
            bool noAck = false;
            BasicGetResult result = model.BasicGet("myquen4", noAck);
            if (result == null)
            {
                // No message available at this time.
                return null;
            }
            else
            {
                IBasicProperties props = result.BasicProperties;
                byte[] body = result.Body;
                var msg = System.Text.Encoding.UTF8.GetString(body);
                return msg;
            }
        }

        private static IModel GetChannel()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = "amqp://test:test@192.168.142.133:5672/";

            var conn = factory.CreateConnection();
            var model = conn.CreateModel();
            return model;
        }
    }
}
