using DTOs;
using EasyNetQ;
using Utilities;

namespace Core
{
    public class OrderController : IOrderController
    {
        public Order Create()
        {
            return OrderFactory.CreateOrder;
        }

        public string CreateAndSerialize()
        {
            return Serializer.XmlSerializeToString(OrderFactory.CreateOrder);
        }

        public string Serialize(Order order)
        {
            return Serializer.XmlSerializeToString(order);
        }

        public byte[] Encrypt(byte[] key, byte[] vector, string orderSerialized)
        {
            var encrypter = new Encrypter();
            return encrypter.EncryptStringToBytes(orderSerialized, key, vector);
        }

        public byte[] Encrypt(string orderSerialized)
        {
            var encrypter = new Encrypter();
            var key = encrypter.GenerateKey();
            var vector = encrypter.GenerateVector();

            return encrypter.EncryptStringToBytes(orderSerialized, key, vector);
        }

        public void Publish(byte[] message, IBus bus)
        {
            bus.Publish(message);
        }
    }
}
