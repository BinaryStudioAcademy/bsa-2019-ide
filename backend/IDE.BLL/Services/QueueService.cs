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
        private readonly IMessageProducerScope _messageProducerScopeBuild;
        private readonly IMessageProducerScope _messageProducerScopeRun;
        private readonly IMessageConsumerScope _messageConsumerScopeBuild;
        private readonly IMessageConsumerScope _messageConsumerScopeRun;
        private readonly ILogger<QueueService> _logger;
        private readonly INotificationService _notificationService;
        private static bool isBuildConsumerSubscribed = false;
        private static bool isRunConsumerSubscribed = false;

        public QueueService(IMessageProducerScopeFactory messageProducerScopeFactory,
                            IMessageConsumerScopeFactory messageConsumerScopeFactory,
                            ILogger<QueueService> logger,
                            INotificationService notificationService)
        {

            _messageProducerScopeRun = messageProducerScopeFactory.Open(new MessageScopeSettings
            {
                ExchangeName = "IdeExchangeRun",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendRunRequestQueue",
                RoutingKey = "runRequest"
            }, QueueType.Run);
            _messageProducerScopeBuild = messageProducerScopeFactory.Open(new MessageScopeSettings
            {
                ExchangeName = "IdeExchangeBuild",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendBuildRequestQueue",
                RoutingKey = "buildRequest"
            }, QueueType.Build);

            _messageConsumerScopeBuild = messageConsumerScopeFactory.Connect(new MessageScopeSettings
            {
                ExchangeName = "BuildServerExchangeBuild",
                ExchangeType = ExchangeType.Direct,
                QueueName = "BuildResultQueue",
                RoutingKey = "buildResponse"
            }, QueueType.Build);
            _messageConsumerScopeRun = messageConsumerScopeFactory.Connect(new MessageScopeSettings
            {
                ExchangeName = "BuildServerExchangeRun",
                ExchangeType = ExchangeType.Direct,
                QueueName = "RunResultQueue",
                RoutingKey = "runResponse"
            }, QueueType.Run);

            _logger = logger;
            _notificationService = notificationService;
            if (!isBuildConsumerSubscribed)
            {
                _messageConsumerScopeBuild.MessageConsumer.Received += MessageBuildConsumer_Received;
                isBuildConsumerSubscribed = true;
            }
            if (!isRunConsumerSubscribed)
            {
                _messageConsumerScopeRun.MessageConsumer.Received += MessageRunConsumer_Received;
                isRunConsumerSubscribed = true;
            }
        }

        private void MessageBuildConsumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            var message = Encoding.UTF8.GetString(@event.Body);
            var buildResult = JsonConvert.DeserializeObject<BuildResultDTO>(message);

            var notification = new NotificationDTO();
            if (buildResult.WasBuildSucceeded)
                notification.Message = "Build status: Success)";
            else
                notification.Message = "Build status: Failed(";
            
            _notificationService.SendNotification(buildResult.ProjectId, notification);
            _messageConsumerScopeBuild.MessageConsumer.SetAcknowledge(@event.DeliveryTag, true);
        }

        private void MessageRunConsumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            var message = Encoding.UTF8.GetString(@event.Body);
            var buildResult = JsonConvert.DeserializeObject<RunResultDTO>(message);

            var notification = new NotificationDTO() { Message = "anhkjsdghabsl" };

            _notificationService.SendNotification(buildResult.ProjectId, notification);
            _messageConsumerScopeBuild.MessageConsumer.SetAcknowledge(@event.DeliveryTag, true);
        }

        public bool SendBuildMessage(string value)
        {
            try
            {
                //here will be sent build params to build server
                _messageProducerScopeBuild.MessageProducer.Send(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SendRunMessage(string value)
        {
            try
            {
                _messageProducerScopeRun.MessageProducer.Send(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _messageProducerScopeBuild.Dispose();
            _messageProducerScopeRun.Dispose();
        }
    }
}
