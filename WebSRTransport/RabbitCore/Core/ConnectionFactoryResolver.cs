using MassTransit;
using RabbitMQ.Client;
using System;
using System.Threading;

namespace RabbitCore.Core
{
    public static class ConnectionFactoryResolver
    {
        public const string RabbitMqCS = "amqps://yerzaidf:cdQx6kwmCODeQNi01UV2wV5_ZcqdjMDs@porpoise.rmq.cloudamqp.com/yerzaidf";
        public const string RabbitMqLogin = "guest";
        public const string RabbitMqPassword = "guest";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localhost"></param>
        /// <returns></returns>
        public static ConnectionFactory CreateByLocal(string localhost)
        {
            return new ConnectionFactory { HostName = localhost };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionUri"></param>
        /// <returns></returns>
        public static ConnectionFactory CreateByService(string connectionUri = null)
        {
            if (connectionUri is null)
                connectionUri = RabbitMqCS;
            return new ConnectionFactory { Uri = new Uri(connectionUri) };
        }


        public static IBusControl CreateBusControl()
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(RabbitMqCS));

                //cfg.ReceiveEndpoint("order-events-listener", e =>
                //{
                //    e.Consumer<TConsumer>();
                //});
            });
            return busControl;
        }
    }
}
