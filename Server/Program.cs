using System;
using RabbitMQ.Client;

namespace Server
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Server Starting");
            Console.WriteLine();

            var server = new Consumer();
            server.Start();

            Console.Read();
        }
    }
}
