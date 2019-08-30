using RabbitMQ.Client;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.Settings;

namespace RabbitMQ.Shared.QueueServices
{
    public class MessageConsumerScopeFactory : IMessageConsumerScopeFactory
    {
        private readonly IConnectionFactory _connectionFactory;
        private IMessageConsumerScope _mqConsumerScope;

        public MessageConsumerScopeFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IMessageConsumerScope Open(MessageScopeSettings messageScopeSettings)
        {
            if (_mqConsumerScope == null)
                _mqConsumerScope = new MessageConsumerScope(_connectionFactory, messageScopeSettings);

            return _mqConsumerScope;
        }

        public IMessageConsumerScope Connect(MessageScopeSettings messageScopeSettings)
        {
            var mqConsumerScope = Open(messageScopeSettings);
            mqConsumerScope.MessageConsumer.Connect();

            return mqConsumerScope;
        }        
    }
}
