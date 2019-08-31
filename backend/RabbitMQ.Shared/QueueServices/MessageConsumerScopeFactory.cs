using RabbitMQ.Client;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.ModelsDTO;
using RabbitMQ.Shared.Settings;

namespace RabbitMQ.Shared.QueueServices
{
    public class MessageConsumerScopeFactory : IMessageConsumerScopeFactory
    {
        private readonly IConnectionFactory _connectionFactory;
        private IMessageConsumerScope _mqConsumerScopeBuild;
        private IMessageConsumerScope _mqConsumerScopeRun;

        public MessageConsumerScopeFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IMessageConsumerScope Open(MessageScopeSettings messageScopeSettings, QueueType type)
        {
            switch (type)
            {
                case QueueType.Build:
                    if (_mqConsumerScopeBuild == null)
                    {
                        _mqConsumerScopeBuild = new MessageConsumerScope(_connectionFactory, messageScopeSettings);
                        _mqConsumerScopeBuild.MessageConsumer.Connect();
                    }
                    return _mqConsumerScopeBuild;
                case QueueType.Run:
                    if (_mqConsumerScopeRun == null)
                    {
                        _mqConsumerScopeRun = new MessageConsumerScope(_connectionFactory, messageScopeSettings);
                        _mqConsumerScopeRun.MessageConsumer.Connect();
                    }
                    return _mqConsumerScopeRun;
            }
            return null;
        }
        public IMessageConsumerScope Connect(MessageScopeSettings messageScopeSettings, QueueType type)
        {
            var mqConsumerScope = Open(messageScopeSettings, type);
            //mqConsumerScope.MessageConsumer.Connect();

            return mqConsumerScope;
        }        
    }
}
