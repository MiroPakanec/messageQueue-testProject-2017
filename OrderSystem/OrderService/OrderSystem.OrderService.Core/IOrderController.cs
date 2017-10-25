using DTOs;
using EasyNetQ;

namespace Core
{
    public interface IOrderController
    {
        Order Create();
        string CreateAndSerialize();
        string Serialize(Order order);

        byte[] Encrypt(byte[] key, byte[] vector, string serializedOrder);
        byte[] Encrypt(string serializedOrder);

        void Publish(byte[] message, IBus bus);
    }
}
