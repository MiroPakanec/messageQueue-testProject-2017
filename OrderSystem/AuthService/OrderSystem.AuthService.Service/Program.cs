using System;
using EasyNetQ;

namespace OrderSystem.AuthService.Service
{
    class Program
    {
        private const string Host = "swan.rmq.cloudamqp.com";
        private const string Vhost = "naghkhhc";
        private const string User = "naghkhhc";
        private const string Password = "uRHTZEgVK7KZKcvrXe1WjgQpqUBK1y_M";

        static void Main(string[] args)
        {
            Startup();

            ServiceManager.Run();

            Console.ReadLine();
        }

        private static void Startup()
        {
            Console.WriteLine("Starting Authentication service...");
        }

        private static void Subscribe()
        {
            var bus = RabbitHutch.CreateBus($"host={Host};virtualhost={Vhost};username={User};password={Password}");
            bus.Subscribe<string>("OrderSystem.AuthService.TestQueue", message =>
            {
                Console.WriteLine($"Recieved message: {message}.");
            });
        }
    }
}
