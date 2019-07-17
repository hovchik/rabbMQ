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
        }
    }
}
