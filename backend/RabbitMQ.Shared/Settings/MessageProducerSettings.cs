using RabbitMQ.Client;

namespace RabbitMQ.Shared.Settings
{
    public class MessageProducerSettings
    {
        public IModel Channel { get; set; }

        public PublicationAddress PublicationAddress { get; set; }
    }
}
