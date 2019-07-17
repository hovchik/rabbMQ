using System;
using System.Text;
using RabbitMQ.Client;

namespace rabbMQ
{
    class Program
    {


        static void Main(string[] args)
        {

            var sender = new Sender();

            while (true)
            {
                var message = Console.ReadLine();
                if (message == "x")
                    break;

                sender.Send(message);
            }

            //var connectionFactory = new ConnectionFactory
            //{
            //    UserName =UserName,
            //    HostName = HostName,
            //    Password = Password
            //};
            //var connection = connectionFactory.CreateConnection();

            //var model = connection.CreateModel();
            ////model.QueueDeclare("NewQueue", true, true, false);
            ////model.ExchangeDeclare("NewExchange", ExchangeType.Topic, true, false);

            ////model.QueueBind("NewQueue", "NewExchange", "test");

            //var property = model.CreateBasicProperties();
            //property.Persistent = true;

            //byte[] message = Encoding.Default.GetBytes("test this message");

            //model.BasicPublish(exchange: "",
            //    routingKey: "myQueue",
            //    basicProperties: null,
            //    body: message);

            //Console.Read();
        }
    }
}
