using EasyNetQ;
using OrderSystem.DecrypterService.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.DecrypterService.Service
{
    public class Service
    {
        private readonly IDecrypterController _controller;
        private readonly IBus _bus;

        public Service(IDecrypterController controller, IBus bus)
        {
            _controller = controller;
            _bus = bus;
        }

        public void Start()
        {
            _bus.Subscribe<byte[]>("OrderSystem.DecrypterService.TestQueue", message =>
            {
                var decryptedMessage = _controller.Decrypt(message);
                Console.WriteLine($"Recieved Order message, at: {DateTime.Now}.");

                _controller.Publish(decryptedMessage, _bus);
                Console.WriteLine($"Published Order message, at: {DateTime.Now}.");
            });
        }
    }
}
