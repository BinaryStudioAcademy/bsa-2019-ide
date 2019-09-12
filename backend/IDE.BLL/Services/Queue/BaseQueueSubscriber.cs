using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Shared.Interfaces;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IDE.BLL.Services.Queue
{
    public abstract class BaseQueueSubscriber : BackgroundService
    {
        protected readonly IMessageConsumerScopeFactory _messageConsumerScopeFactory;
        protected readonly ILogger<BaseQueueSubscriber> _logger;

        //private readonly INotificationService _notificationService;

        private IMessageConsumerScope _messageConsumerScopeBuild;

        public BaseQueueSubscriber(IMessageConsumerScopeFactory messageConsumerScopeFactory,
                            ILogger<BaseQueueSubscriber> logger)
        {
            _messageConsumerScopeFactory = messageConsumerScopeFactory;
            _logger = logger;
            InitRabbitMQ();
        }

        /// <summary>
        /// Create queue
        /// </summary>
        private void InitRabbitMQ()
        {
            _messageConsumerScopeBuild = InitConsumer();
            //_messageConsumerScopeBuild.MessageConsumer.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        public abstract IMessageConsumerScope InitConsumer();

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            _messageConsumerScopeBuild.MessageConsumer.Received += async (ch, ea) =>
            {
                // received message  
                var content = Encoding.UTF8.GetString(ea.Body);
                _logger.LogInformation("Event received");
                // handle the received message  
                try
                {
                    await HandleMessageAsync(content);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Event error");
                }
                _messageConsumerScopeBuild.MessageConsumer.SetAcknowledge(ea.DeliveryTag, true);
            };

            //_messageConsumerScopeBuild.MessageConsumer.Shutdown += OnConsumerShutdown;
            //_messageConsumerScopeBuild.MessageConsumer.Registered += OnConsumerRegistered;
            //_messageConsumerScopeBuild.MessageConsumer.Unregistered += OnConsumerUnregistered;
            //_messageConsumerScopeBuild.MessageConsumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            //_channel.BasicConsume("demo.queue.log", false, consumer);
        }

        public abstract Task HandleMessageAsync(string content);

        //private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e) { }
        //private void OnConsumerUnregistered(object sender, ConsumerEventArgs e) { }
        //private void OnConsumerRegistered(object sender, ConsumerEventArgs e) { }
        //private void OnConsumerShutdown(object sender, ShutdownEventArgs e) { }
        //private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e) { }

        public override void Dispose()
        {
            _messageConsumerScopeBuild.Dispose();
            base.Dispose();
        }
    }
}
