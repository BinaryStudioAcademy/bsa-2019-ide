using System;

namespace RabbitMQ.Shared.Interfaces
{
    public interface IMessageProducerScope : IDisposable
    {
        IMessageProducer MessageProducer { get; }

    }
}
