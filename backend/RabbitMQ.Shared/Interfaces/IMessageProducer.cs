namespace RabbitMQ.Shared.Interfaces
{
    public interface IMessageProducer
    {
        void Send(string message, string type = null);
    }
}
