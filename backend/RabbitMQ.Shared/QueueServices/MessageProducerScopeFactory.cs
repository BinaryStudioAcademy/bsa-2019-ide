using RabbitMQ.Client;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.ModelsDTO;
using RabbitMQ.Shared.Settings;

namespace RabbitMQ.Shared.QueueServices
{
    public class MessageProducerScopeFactory : IMessageProducerScopeFactory
    {
        private readonly IConnectionFactory _connectionFactory;

        public MessageProducerScopeFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IMessageProducerScope Open(MessageScopeSettings messageScopeSettings)
        {

            var  _mqProducerScopeRun = new MessageProducerScope(_connectionFactory, messageScopeSettings);
            return _mqProducerScopeRun;
        }
    }
}
