using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using OrderSystem.AuthService.Core;
using OrderSystem.AuthService.DAL;

namespace OrderSystem.AuthService.Service
{
    internal static class ServiceManager
    {
        private static System.IServiceProvider _serviceProvider;
        private static IBus _bus;

        public static void Run()
        {
            ConfigureServiceProvider();
            ConfigureBus();

            new Service(_serviceProvider.GetService<IAuthController>(), _bus).Start();
        }

        private static void ConfigureServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<IUserAccess, UserAccess>()
                .AddSingleton<IAuthController, AuthController>()
                .BuildServiceProvider();
        }

        private static void ConfigureBus()
        {
            const string Host = "swan.rmq.cloudamqp.com";
            const string Vhost = "naghkhhc";
            const string User = "naghkhhc";
            const string Password = "uRHTZEgVK7KZKcvrXe1WjgQpqUBK1y_M";

            _bus = RabbitHutch.CreateBus($"host={Host};virtualhost={Vhost};username={User};password={Password}");
        }
    }
}
