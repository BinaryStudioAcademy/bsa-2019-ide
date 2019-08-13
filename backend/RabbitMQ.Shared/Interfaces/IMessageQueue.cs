using System;
using RabbitMQ.Client;

namespace RabbitMQ.Shared.Interfaces
{
    public interface IMessageQueue : IDisposable
    {
        IModel Channel { get; set; }
    }
}
