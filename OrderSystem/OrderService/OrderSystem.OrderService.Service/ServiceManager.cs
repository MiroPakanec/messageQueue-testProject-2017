using Core;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.OrderService.Service
{
    public static class ServiceManager
    {
        private static System.IServiceProvider _serviceProvider;
        private static IBus _bus;

        public static void Run()
        {
            ConfigureServiceProvider();
            ConfigureBus();

            new OrderService(_serviceProvider.GetService<IOrderController>(), _bus).Start();
        }

        private static void ConfigureServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<IOrderController, OrderController>()
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
