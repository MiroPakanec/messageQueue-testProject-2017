using System;
using EasyNetQ;
using OrderSystem.DecrypterService.Core;

namespace OrderSystem.DecrypterService.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup();

            ServiceManager.Run();

            Console.ReadLine();
        }

        private static void Startup()
        {
            Console.WriteLine("Starting Decryption Service...");
        }
    }
}
