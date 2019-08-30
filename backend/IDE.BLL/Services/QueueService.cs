using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.ModelsDTO;
using RabbitMQ.Shared.Settings;
using System.Text;

namespace IDE.BLL.Services
{
    public class QueueService : IQueueService
    {
        private readonly IMessageProducerScope _messageProducerScope;
        private readonly IMessageConsumerScope _messageConsumerScope;
        private readonly ILogger<QueueService> _logger;
        private readonly INotificationService _notificationService;
        private static bool isConsumerSubscribed = false;

        public QueueService(IMessageProducerScopeFactory messageProducerScopeFactory,
                            IMessageConsumerScopeFactory messageConsumerScopeFactory,
                            ILogger<QueueService> logger,
                            INotificationService notificationService)
        {
            _messageProducerScope = messageProducerScopeFactory.Open(new MessageScopeSettings
            {
                ExchangeName = "IdeExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "ProjectsForBuildingQueue",
                RoutingKey = "request"
            });

            _messageConsumerScope = messageConsumerScopeFactory.Connect(new MessageScopeSettings
            {
                ExchangeName = "BuildServerExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "BuildResultQueue",
                RoutingKey = "responce"
            });

            _logger = logger;
            _notificationService = notificationService;
            if (!isConsumerSubscribed)
            {
                _messageConsumerScope.MessageConsumer.Received += MessageConsumer_Received;
                isConsumerSubscribed = true;
            }
        }

        private void MessageConsumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            var message = Encoding.UTF8.GetString(@event.Body);
            var buildResult = JsonConvert.DeserializeObject<BuildResultDTO>(message);

            var notification = new NotificationDTO();
            if (buildResult.WasBuildSucceeded)
                notification.Message = "Build status: Success)";
            else
                notification.Message = "Build status: Failed(";

            _notificationService.SendNotification(buildResult.ProjectId, notification);
            _messageConsumerScope.MessageConsumer.SetAcknowledge(@event.DeliveryTag, true);
        }

        public bool SendMessage(string message)
        {
            try
            {
                _messageProducerScope.MessageProducer.Send(message);
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
