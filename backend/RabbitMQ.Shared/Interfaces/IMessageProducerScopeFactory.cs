using RabbitMQ.Shared.ModelsDTO;
using RabbitMQ.Shared.Settings;

namespace RabbitMQ.Shared.Interfaces
{
    public interface IMessageProducerScopeFactory
    {
        IMessageProducerScope Open(MessageScopeSettings messageScopeSettings, QueueType type);
    }
}
