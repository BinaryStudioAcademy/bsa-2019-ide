using RabbitMQ.Shared.Settings;

namespace RabbitMQ.Shared.Interfaces
{
    public interface IMessageConsumerScopeFactory
    {
        IMessageConsumerScope Open(MessageScopeSettings messageScopeSettings);
        IMessageConsumerScope Connect(MessageScopeSettings messageScopeSettings);
    }
}
