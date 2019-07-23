using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace rabbMQ
{
    class Sender : IDisposable
    {
        private const string HostName = "localhost";
        private const string UserName = "guest";
        private const string Password = "guest";
        private const string QueueName = "myQueue";
        private const string ExchangeName = "Server";

        private ConnectionFactory _factory;
        private IModel _model;
        private IConnection _connection;
        public Sender()
        {
            _factory = new ConnectionFactory
            {
                UserName = UserName,
                HostName = HostName,
                Password = Password
            };
            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();
            

        }
        public void Send(string message)
        {
            var property = _model.CreateBasicProperties();
            property.Persistent = true;
            byte[] mess = Encoding.Default.GetBytes(message);

            _model.BasicPublish(exchange: ExchangeName,
                routingKey: QueueName,
                basicProperties: property,
                body: mess);
        }

        public void Dispose()
        {
        }
    }
}
