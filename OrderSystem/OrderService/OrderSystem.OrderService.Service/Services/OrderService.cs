using Core;
using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OrderSystem.OrderService.Service
{
    public class OrderService : IService
    {
        private IOrderController _controller;
        private IBus _bus;

        public OrderService(IOrderController controller, IBus bus)
        {
            _controller = controller;
            _bus = bus;
        }

        public void Start()
        {
            while (true)
            {
                var order = _controller.Create();
                var orderSerialized = _controller.Serialize(order);
                var message = _controller.Encrypt(orderSerialized);

                _controller.Publish(message, _bus);

                Print($"New Order ID: {order.OrderId}. Username: {order.ResponsibleSeller.Username}, Password: {order.ResponsibleSeller.Password}");

                Thread.Sleep(5000);
            }
        }

        public void Print(string message)
        {
            Console.WriteLine($"Published message: {message}, at: {DateTime.Now}.");
        }
    }
}
