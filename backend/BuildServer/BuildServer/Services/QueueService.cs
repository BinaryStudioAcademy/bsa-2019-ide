using BuildServer.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Shared.Interfaces;
using RabbitMQ.Shared.Settings;
using System;
using System.IO;
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
                ExchangeName = "ClientExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendRequestQueue",
                RoutingKey = "request"
            });

            _messageConsumerScope = messageConsumerScopeFactory.Connect(new MessageScopeSettings
            {
                ExchangeName = "ServerExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "SendResponceQueue",
                RoutingKey = "responce"
            });
            _messageConsumerScope.MessageConsumer.Received += MessageConsumer_Received;
            _worker = new Worker(builder, fileArchiver, azureService);
        }

        private void MessageConsumer_Received(object sender, BasicDeliverEventArgs evn)
        {
            //just make sure that receiving works. Will be removed
            var message = Encoding.UTF8.GetString(evn.Body);
            /*_azureService.Download(message)*/;
            var isBuildSucceeded = _worker.Work(message);

            _messageConsumerScope.MessageConsumer.SetAcknowledge(evn.DeliveryTag, true);
            if (isBuildSucceeded)
                SendMessage($"Build status: Success)");
            else
                SendMessage($"Build status: Failed(");
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
