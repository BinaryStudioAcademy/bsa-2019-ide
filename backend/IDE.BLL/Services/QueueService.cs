using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Common;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.Settings;
using System.Diagnostics;
using System.Text;

namespace IDE.BLL.Services
{
    public class QueueService : IQueueService
    {
        private readonly IMessageProducerScope _messageProducerScope;
        private readonly IMessageConsumerScope _messageConsumerScope;
        private readonly ILogger<QueueService> _logger;
        private readonly INotificationService _notificationService;

        public QueueService(IMessageProducerScopeFactory messageProducerScopeFactory,
                            IMessageConsumerScopeFactory messageConsumerScopeFactory,
                            ILogger<QueueService> logger,
                            INotificationService notificationService)
        {
            _messageProducerScope = messageProducerScopeFactory.Open(new MessageScopeSettings
            {
                ExchangeName = "ClientExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendResponceQueue",
                RoutingKey = "responce"
            });

            _messageConsumerScope = messageConsumerScopeFactory.Connect(new MessageScopeSettings
            {
                ExchangeName = "ServerExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendRequestQueue",
                RoutingKey = "request"
            });

            _logger = logger;
            _notificationService = notificationService;
        }

        public void ConfigureSubscription()
        {
            _messageConsumerScope.MessageConsumer.Received += MessageConsumer_Received;
        }

        private void MessageConsumer_Received(object sender, BasicDeliverEventArgs e)
        {
            //just make sure that receiving works. Will be removed
            var message = Encoding.UTF8.GetString(e.Body);
            Debug.WriteLine($"--------------------------------------------------{message} receiwed");

            _messageConsumerScope.MessageConsumer.SetAcknowledge(e.DeliveryTag, true);

            var notification = new NotificationDTO()
            {
                Message = message
            };

            _notificationService.SendNotification(31, notification);
        }

        public bool SendMessage(string value, int projectId)
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
