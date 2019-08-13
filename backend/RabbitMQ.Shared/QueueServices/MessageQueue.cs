using RabbitMQ.Client;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.Settings;

namespace RabbitMQ.Shared.QueueServices
{
    public class MessageQueue : IMessageQueue
    {
        private IConnection _connection;
        public IModel Channel { get; set; }

        public MessageQueue(IConnectionFactory conectionFactory)
        {
            _connection = conectionFactory.CreateConnection();
            Channel = _connection.CreateModel();
        }

        public MessageQueue(IConnectionFactory conectionFactory, MessageScopeSettings messageScopeSettings)
            : this(conectionFactory)
        {
            DeclareExchange(messageScopeSettings.ExchangeName, messageScopeSettings.ExchangeType);

            if(messageScopeSettings.QueueName != null)
            {
                BindQueue(messageScopeSettings.ExchangeName, messageScopeSettings.RoutingKey, messageScopeSettings.QueueName);
            }
        }

        private void DeclareExchange(string exchangeName, string exchangeType)
        {
            Channel.ExchangeDeclare(exchangeName, exchangeType ?? string.Empty);
        }

        private void BindQueue(string exchangeName, string routingKey, string queueName)
        {
            Channel.QueueDeclare(queueName, true, false, false);
            Channel.QueueBind(queueName, exchangeName, routingKey);
        }

        public void Dispose()
        {
            Channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
