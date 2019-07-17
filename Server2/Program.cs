using System;
using Server;

namespace Server2
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
