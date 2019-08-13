using RabbitMQ.Client;

namespace RabbitMQ.Shared.Settings
{
    public class MessageConsumerSettings
    {
        public IModel Channel { get; internal set; }

        public bool SequentialFetch { get; set; } = true;

        public bool AutoAcknowledge { get; set; } = false;

        public string QueueName { get; set; }
    }
}
