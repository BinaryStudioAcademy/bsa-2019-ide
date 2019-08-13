using RabbitMQ.Client;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.Settings;

namespace RabbitMQ.Shared.QueueServices
{
    public class MessageConsumerScopeFactory : IMessageConsumerScopeFactory
    {
        private readonly IConnectionFactory _connectionFactory;


        public MessageConsumerScopeFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IMessageConsumerScope Open(MessageScopeSettings messageScopeSettings)
        {
            return new MessageConsumerScope(_connectionFactory, messageScopeSettings);
        }

        public IMessageConsumerScope Connect(MessageScopeSettings messageScopeSettings)
        {
            var mqConsumerScope = Open(messageScopeSettings);
            mqConsumerScope.MessageConsumer.Connect();

            return mqConsumerScope;
        }        
    }
}
