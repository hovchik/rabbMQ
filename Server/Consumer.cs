using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;

namespace Server
{
    class Consumer
    {
        private const string HostName = "localhost";
        private const string UserName = "guest";
        private const string Password = "guest";
        private const string QueueName = "Q1";

        //public Action<string> OnReceiveMessage;
        private ConnectionFactory _factory;
        private IModel _model;
        private IConnection _connection;
        private Subscription _subscription;

        private delegate void ConsumeDelegate();

        public Consumer()
        {
             _factory = new ConnectionFactory
             {
                 UserName = UserName,
                 HostName = HostName,
                 Password = Password
             };
             _connection = _factory.CreateConnection();
             _model = _connection.CreateModel();
            _model.BasicQos(0,1,false);

        }

        public void Start()
        {
            _subscription = new Subscription(_model,QueueName,false);

            var consume = new ConsumeDelegate(Poll);
            consume.Invoke();

            //var cons = new EventingBasicConsumer(_model);

            //_model.BasicConsume(QueueName, false, cons);

            //cons.Received += Cons_Received;
        }

        private void Poll()
        {
            while (true)
            {
                var delivery = _subscription.Next();
                if (delivery != null)
                {
                    User user = JsonConvert.DeserializeObject<User>(Encoding.Default.GetString(delivery.Body));
                    Console.WriteLine($"UserID: {user.Id}  UserName: {user.UserName}  Email: {user.Email}");
                    _subscription.Ack(delivery);
                }
            }
        }

        private void Cons_Received(object sender, BasicDeliverEventArgs e)
        {
            //while (true)
            //{
                var delivery = Encoding.Default.GetString(e.Body);
                Console.WriteLine(delivery);
                Console.WriteLine();
                _model.BasicAck(e.DeliveryTag,false);
           //}
        }
    }
}
