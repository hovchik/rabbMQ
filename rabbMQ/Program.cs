using System;
using System.Text;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace rabbMQ
{
    class Program
    {
        public static int Id { get; set; }
        static void Main(string[] args)
        {

            var sender = new Sender();
            User user;
            while (true)
            {
                user = new User();
                Console.WriteLine("Enter user name");
                var uName = Console.ReadLine();
                if (uName == "x")
                    break;
                user.UserName = uName;
                Console.WriteLine("Enter user email");
                var email = Console.ReadLine();
                user.Email = email;
                user.Id = ++Id;
                var sendServer = JsonConvert.SerializeObject(user);
                sender.Send(sendServer);
                //sender.Send(uName);
            }
        }
    }
}
