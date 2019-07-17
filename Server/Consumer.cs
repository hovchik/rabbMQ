using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Server
{
    class Consumer
    {
        private const string HostName = "localhost";
        private const string UserName = "guest";
        private const string Password = "guest";
        private const string QueueName = "myQueue";

        //public Action<string> OnReceiveMessage;
        private ConnectionFactory _factory;
        private IModel _model;
        private IConnection _connection;

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
            var cons = new EventingBasicConsumer(_model);

            _model.BasicConsume(QueueName, false, cons);

            cons.Received += Cons_Received;
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
