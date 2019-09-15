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
        private readonly ILogger<QueueService> _logger;

        public QueueService(IMessageProducerScopeFactory messageProducerScopeFactory,
                            IMessageConsumerScopeFactory messageConsumerScopeFactory,
                            ILogger<QueueService> logger)
        {

            _messageProducerScopeRun = messageProducerScopeFactory.Open(new MessageScopeSettings
            {
                ExchangeName = "IdeExchangeRun",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendRunRequestQueue",
                RoutingKey = "runRequest"
            });
            _messageProducerScopeBuild = messageProducerScopeFactory.Open(new MessageScopeSettings
            {
                ExchangeName = "IdeExchangeBuild",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendBuildRequestQueue",
                RoutingKey = "buildRequest"
            });

            _logger = logger;
        }

        public bool SendBuildMessage(string value)
        {
            try
            {
                _logger.LogInformation("Recevid build message result");
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
