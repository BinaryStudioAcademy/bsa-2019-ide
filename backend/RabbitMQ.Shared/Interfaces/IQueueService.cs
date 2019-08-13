namespace RabbitMQ.Shared.Interfaces
{
    public interface IQueueService
    {
        bool PostValue(string value);
    }
}
