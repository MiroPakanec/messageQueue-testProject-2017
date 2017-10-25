using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.DecrypterService.Core
{
    public interface IDecrypterController
    {
        string Decrypt(byte[] message);
        void Publish(string message, IBus bus);
    }
}
