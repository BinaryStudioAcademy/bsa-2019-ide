using IDE.BLL.Interfaces;
using IDE.BLL.Services.Queue;
using IDE.Common.ModelsDTO.DTO.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.ModelsDTO;
using RabbitMQ.Shared.Settings;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class RunQueueSubscriberService : BaseQueueSubscriber
    {
        private IServiceScopeFactory _serviceScopeFactory;

        public RunQueueSubscriberService(IMessageConsumerScopeFactory messageConsumerScopeFactory,
                            ILogger<BuildQueueSubscriberService> logger,
                            IServiceScopeFactory serviceScopeFactory) : base(messageConsumerScopeFactory, logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public override IMessageConsumerScope InitConsumer()
        {
            return _messageConsumerScopeFactory.Connect(new MessageScopeSettings
            {
                ExchangeName = "BuildServerExchangeRun",
                ExchangeType = ExchangeType.Direct,
                QueueName = "RunResultQueue",
                RoutingKey = "runResponse"
            });

            //_messageConsumerScopeBuild.MessageConsumer.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }


        public override async Task HandleMessageAsync(string content)
        {
            // we just print this message   
            _logger.LogInformation($"consumer received {content}");
            var runResult = JsonConvert.DeserializeObject<RunResultDTO>(content);

            var notification = new NotificationDTO() { Message = runResult.Result };

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                await notificationService.SendRunResultNotificationToUser(notification, runResult.ConnectionId);
            }

        }
    }
}
