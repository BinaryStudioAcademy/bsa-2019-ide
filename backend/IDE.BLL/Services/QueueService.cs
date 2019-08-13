using IDE.BLL.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Shared.Interfaces;
using System.Text;

namespace IDE.BLL.Services
{
    public class QueueService : IQueueService
    {
        private readonly IMessageProducerScope _messageProducerScope;
        private readonly IMessageConsumerScope _messageConsumerScope;

        public QueueService(IMessageProducerScopeFactory messageProducerScopeFactory, IMessageConsumerScopeFactory messageConsumerScopeFactory)
        {
            _messageProducerScope = messageProducerScopeFactory.Open(new RabbitMQ.Shared.Settings.MessageScopeSettings
            {
                ExchangeName = "ClientExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendResponceQueue",
                RoutingKey = "responce"
            });

            _messageConsumerScope = messageConsumerScopeFactory.Connect(new RabbitMQ.Shared.Settings.MessageScopeSettings
            {
                ExchangeName = "ServerExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendRequestQueue",
                RoutingKey = "request"
            });

            _messageConsumerScope.MessageConsumer.Received += MessageConsumer_Received; ; ;
        }

        private void MessageConsumer_Received(object sender, BasicDeliverEventArgs e)
        {
            //just make sure that receiving works. Will be removed
            var message = Encoding.UTF8.GetString(e.Body);
            System.Diagnostics.Debug.WriteLine($"--------------------------------------------------{message}");

            _messageConsumerScope.MessageConsumer.SetAcknowledge(e.DeliveryTag, true);
        }

        public bool SendMessage(string value)
        {
            try
            {
                //here will be sent build params to build server
                _messageProducerScope.MessageProducer.Send(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _messageProducerScope.Dispose();
        }
    }
}
