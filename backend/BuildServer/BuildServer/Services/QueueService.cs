using BuildServer.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.ModelsDTO;
using RabbitMQ.Shared.Settings;
using System.Text;

namespace BuildServer.Services
{
    public class QueueService : IQueueService
    {
        private readonly IMessageProducerScope _messageProducerScopeBuild;
        private readonly IMessageProducerScope _messageProducerScopeRun;
        private readonly IMessageConsumerScope _messageConsumerScopeBuild;
        private readonly IMessageConsumerScope _messageConsumerScopeRun;
        private readonly Worker _worker;

        public QueueService(IMessageProducerScopeFactory messageProducerScopeFactory,
                            IMessageConsumerScopeFactory messageConsumerScopeFactory,
                            IAzureService azureService,
                            IBuilder builder,
                            IFileArchiver fileArchiver)
        {
            
            _messageProducerScopeBuild = messageProducerScopeFactory.Open(new MessageScopeSettings
            {
                ExchangeName = "BuildServerExchangeBuild",
                ExchangeType = ExchangeType.Direct,
                QueueName = "BuildResultQueue",
                RoutingKey = "buildResponse"
            }, QueueType.Build);
            _messageProducerScopeRun = messageProducerScopeFactory.Open(new MessageScopeSettings
            {
                ExchangeName = "BuildServerExchangeRun",
                ExchangeType = ExchangeType.Direct,
                QueueName = "RunResultQueue",
                RoutingKey = "runResponse"
            }, QueueType.Run);

            _messageConsumerScopeRun = messageConsumerScopeFactory.Connect(new MessageScopeSettings
            {
                ExchangeName = "IdeExchangeRun",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendRunRequestQueue",
                RoutingKey = "runRequest"
            }, QueueType.Run);
            _messageConsumerScopeBuild = messageConsumerScopeFactory.Connect(new MessageScopeSettings
            {
                ExchangeName = "IdeExchangeBuild",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendBuildRequestQueue",
                RoutingKey = "buildRequest"
            }, QueueType.Build);

            _messageConsumerScopeBuild.MessageConsumer.Received += MessageConsumer_BuildReceived;
            _messageConsumerScopeRun.MessageConsumer.Received += MessageConsumer_RunReceived;
            _worker = new Worker(builder, fileArchiver, azureService);
        }

        private void MessageConsumer_BuildReceived(object sender, BasicDeliverEventArgs evn)
        {
            var message = Encoding.UTF8.GetString(evn.Body);
            var projectForBuild = JsonConvert.DeserializeObject<ProjectForBuildDTO>(message);
            var projectName = $"project_{projectForBuild.ProjectId}";
            var isBuildSucceeded = _worker.Work(projectForBuild.UriForProjectDownload, projectName,  out var artifactArchiveUri);

            var buildResult = new BuildResultDTO()
            {
                ProjectId = projectForBuild.ProjectId,
                WasBuildSucceeded = isBuildSucceeded,
                UriForArtifactsDownload = artifactArchiveUri
            };
            
            var jsonMessage = JsonConvert.SerializeObject(buildResult);
            _messageConsumerScopeBuild.MessageConsumer.SetAcknowledge(evn.DeliveryTag, true);
            SendBuildMessage(jsonMessage);
        }

        private void MessageConsumer_RunReceived(object sender, BasicDeliverEventArgs evn)
        {
            var message = Encoding.UTF8.GetString(evn.Body);
            var projectForRun = JsonConvert.DeserializeObject<ProjectForRunDTO>(message);
            var projectName = $"project_{projectForRun.ProjectId}";

            var runningResult = _worker.Run(projectForRun.UriForProjectDownload, projectName);


            var runResult = new RunResultDTO()
            {
                ProjectId = projectForRun.ProjectId,
                Result = runningResult,
                ConnectionId = projectForRun.ConnectionId
            };

            var jsonMessage = JsonConvert.SerializeObject(runResult);
            _messageConsumerScopeRun.MessageConsumer.SetAcknowledge(evn.DeliveryTag, true);
            SendRunMessage(jsonMessage);
        }

        public bool SendBuildMessage(string value)
        {
            try
            {
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
