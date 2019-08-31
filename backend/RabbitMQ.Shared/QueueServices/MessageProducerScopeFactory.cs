using RabbitMQ.Client;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.ModelsDTO;
using RabbitMQ.Shared.Settings;

namespace RabbitMQ.Shared.QueueServices
{
    public class MessageProducerScopeFactory : IMessageProducerScopeFactory
    {
        private readonly IConnectionFactory _connectionFactory;
        private IMessageProducerScope _mqProducerScopeBuild;
        private IMessageProducerScope _mqProducerScopeRun;

        public MessageProducerScopeFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IMessageProducerScope Open(MessageScopeSettings messageScopeSettings, QueueType type)
        {
            switch(type)
            {
                case QueueType.Build:
                    if (_mqProducerScopeBuild == null)
                        _mqProducerScopeBuild = new MessageProducerScope(_connectionFactory, messageScopeSettings);
                    return _mqProducerScopeBuild;
                case QueueType.Run:
                    if (_mqProducerScopeRun == null)
                        _mqProducerScopeRun = new MessageProducerScope(_connectionFactory, messageScopeSettings);
                    return _mqProducerScopeRun;
            }
            return null;
        }
    }
}
