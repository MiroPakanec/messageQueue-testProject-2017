using Core;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using OrderSystem.OrderService.Service;
using System;

//TODO:
// 1. Send encryptedMessage to another MSMQ application (decrypter) that decrypt the message (you can reuse code from the CrypticLogic.cs, you need to create a shared key and vector)
// 2. Send decryptedMessage from decrypter to a MSMQ application that authorizes (authorizer) based on password and username
// 3. Send authorized message to a MSMQ application the check for dublicates (deduber).

//TODO: Extended exercises
// 4. Create a function in this probram that can generate a series of orders, either manual or by using random values.
// 5. Create another MSMQ application, call it sequentialOrderProcess that do 1,2,3 (decrypt, authorize, dublicate) all at once (it only checks for dublicate on its own instance, don't implement shared de-dublicate logic)
// 6. Create a simple round robin router that send distribute load on sequentialOrderProcess and the pipeline described in 1-3
// 7. Test your queue system under heavy load (you can create a counter on each of the application for each messages they have processed).

namespace Service
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
            Console.WriteLine("Starting Order Service...");
        }
    }
}   
