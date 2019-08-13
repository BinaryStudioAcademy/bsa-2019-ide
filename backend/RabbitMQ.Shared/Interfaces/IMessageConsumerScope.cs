using System;

namespace RabbitMQ.Shared.Interfaces
{
    public interface IMessageConsumerScope : IDisposable
    {
        IMessageConsumer MessageConsumer { get;}
    }
}
