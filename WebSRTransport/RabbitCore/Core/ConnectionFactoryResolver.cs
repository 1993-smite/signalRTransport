using RabbitMQ.Client;
using System;

namespace RabbitCore.Core
{
    public static class ConnectionFactoryResolver
    {
        public static ConnectionFactory CreateByLocal(string localhost)
        {
            return new ConnectionFactory { HostName = localhost };
        }

        public static ConnectionFactory CreateByService(string connectionUri = null)
        {
            if (connectionUri is null)
                connectionUri = "amqps://yerzaidf:cdQx6kwmCODeQNi01UV2wV5_ZcqdjMDs@porpoise.rmq.cloudamqp.com/yerzaidf";
            return new ConnectionFactory { Uri = new Uri(connectionUri) };
        }
    }
}
