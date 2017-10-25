using EasyNetQ;
using System;

namespace OrderSystem.DecrypterService.Core
{
    public class DecrypterController : IDecrypterController
    {
        public string Decrypt(byte[] message)
        {
            var key = Decrypter.GenerateKey();
            var vector = Decrypter.GenerateVector();

            return Decrypter.DecryptStringFromBytes(message, key, vector);
        }

        public void Publish(string message, IBus bus)
        {
            bus.Publish(message);
        }
    }
}
