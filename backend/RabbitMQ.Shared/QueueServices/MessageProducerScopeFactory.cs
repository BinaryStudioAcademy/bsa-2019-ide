using RabbitMQ.Client;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.Settings;

namespace RabbitMQ.Shared.QueueServices
{
    public class MessageProducerScopeFactory : IMessageProducerScopeFactory
    {
        private readonly IConnectionFactory _connectionFactory;
        private IMessageProducerScope _mqProducerScope;

        public MessageProducerScopeFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IMessageProducerScope Open(MessageScopeSettings messageScopeSettings)
        {
            if (_mqProducerScope == null)
                _mqProducerScope = new MessageProducerScope(_connectionFactory, messageScopeSettings);

            return _mqProducerScope;
        }
    }
}
