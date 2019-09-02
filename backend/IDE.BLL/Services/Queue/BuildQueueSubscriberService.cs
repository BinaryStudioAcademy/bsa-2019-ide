using IDE.BLL.Interfaces;
using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.ModelsDTO;
using RabbitMQ.Shared.Settings;
using System;
using System.Threading.Tasks;

namespace IDE.BLL.Services.Queue
{
    public class BuildQueueSubscriberService : BaseQueueSubscriber
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        private IMessageConsumerScope _messageConsumerScopeBuild;

        public BuildQueueSubscriberService(IMessageConsumerScopeFactory messageConsumerScopeFactory,
                            ILogger<BuildQueueSubscriberService> logger,
                            IServiceScopeFactory serviceScopeFactory): base(messageConsumerScopeFactory, logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public override IMessageConsumerScope InitConsumer()
        {
            return _messageConsumerScopeFactory.Connect(new MessageScopeSettings
            {
                ExchangeName = "BuildServerExchangeBuild",
                ExchangeType = ExchangeType.Direct,
                QueueName = "BuildResultQueue",
                RoutingKey = "buildResponse"
            });
        }

        public override async Task HandleMessageAsync(string content)
        {
            // we just print this message   
            _logger.LogInformation($"consumer received {content}");

            var buildResult = JsonConvert.DeserializeObject<BuildResultDTO>(content);

            var notification = new NotificationDTO();
            notification.Type = NotificationType.ProjectBuild;
            notification.ProjectId = buildResult.ProjectId;
            notification.DateTime = DateTime.Now;
            if (buildResult.WasBuildSucceeded)
            {
                notification.Message = "Build status: Success)";
                notification.Status = NotificationStatus.Message;
            }
            else
            {
                notification.Message = "Build status: Failed(";
                notification.Status = NotificationStatus.Error;
            }

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                await notificationService.SendNotification(buildResult.ProjectId, notification);
            }
        }
    }
}
