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
        private readonly IMessageProducerScope _messageProducerScope;
        private readonly IMessageConsumerScope _messageConsumerScope;
        private readonly Worker _worker;

        public QueueService(IMessageProducerScopeFactory messageProducerScopeFactory,
                            IMessageConsumerScopeFactory messageConsumerScopeFactory,
                            IAzureService azureService,
                            IBuilder builder,
                            IFileArchiver fileArchiver)
        {
            _messageProducerScope = messageProducerScopeFactory.Open(new MessageScopeSettings
            {
                ExchangeName = "BuildServerExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "BuildResultQueue",
                RoutingKey = "responce"
            });

            _messageConsumerScope = messageConsumerScopeFactory.Connect(new MessageScopeSettings
            {
                ExchangeName = "IdeExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "ProjectsForBuildingQueue",
                RoutingKey = "request"
            });
            _messageConsumerScope.MessageConsumer.Received += MessageConsumer_Received;
            _worker = new Worker(builder, fileArchiver, azureService);
        }

        private void MessageConsumer_Received(object sender, BasicDeliverEventArgs evn)
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
            _messageConsumerScope.MessageConsumer.SetAcknowledge(evn.DeliveryTag, true);
            SendMessage(jsonMessage);
        }

        public bool SendMessage(string value)
        {
            try
            {
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
