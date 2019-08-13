using RabbitMQ.Client.Events;
using System;

namespace RabbitMQ.Shared.Interfaces
{
    public interface IMessageConsumer
    {
        void Connect();

        void SetAcknowledge(ulong deliveryTag, bool processed);

        event EventHandler<BasicDeliverEventArgs> Received;
    }
}
