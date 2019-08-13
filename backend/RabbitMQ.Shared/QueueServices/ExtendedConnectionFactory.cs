using RabbitMQ.Client;
using System;

namespace RabbitMQ.Shared.QueueServices
{
    public class ExtendedConnectionFactory : ConnectionFactory
    {
        public ExtendedConnectionFactory(Uri uri)
        {
            Uri = uri;
            RequestedConnectionTimeout = 30000;
            NetworkRecoveryInterval = TimeSpan.FromSeconds(30);
            AutomaticRecoveryEnabled = true;
            TopologyRecoveryEnabled = true;
            RequestedHeartbeat = 60;
        }
    }
}
