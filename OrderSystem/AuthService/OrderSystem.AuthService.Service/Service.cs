
using System;
using System.Collections.Generic;
using System.Text;
using EasyNetQ;
using OrderSystem.AuthService.Core;

namespace OrderSystem.AuthService.Service
{
    internal class Service
    {
        private readonly IAuthController _controller;
        private readonly IBus _bus;

        public Service(IAuthController controller, IBus bus)
        {
            _controller = controller;
            _bus = bus;
        }

        public void Start()
        {
            _bus.Subscribe<string>("OrderSystem.AuthService.TestQueue", message =>
            {
                Console.WriteLine($"Recieved Order message, at: {DateTime.Now}.");

                var order = _controller.Serialize(message);
                var auth = order.ResponsibleSeller;

                var result = _controller.Authenticate(auth);

                Console.WriteLine(result.ErrorMessage);
            });
        }
    }
}
