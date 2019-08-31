using RabbitMQ.Shared.ModelsDTO;
using RabbitMQ.Shared.Settings;

namespace RabbitMQ.Shared.Interfaces
{
    public interface IMessageConsumerScopeFactory
    {
        IMessageConsumerScope Open(MessageScopeSettings messageScopeSettings, QueueType type);
        IMessageConsumerScope Connect(MessageScopeSettings messageScopeSettings, QueueType type);
    }
}
