using NLog;
using RabbitCore.Core;
using RabbitCore.Core.Listeners;
using RabbitListener.Consumer;
using MassTransit;
using System;
using DB.DBModels;
using System.Threading;

namespace RabbitListener
{
    class Program
    {
        public static NLog.Logger Logger
            = LogManager.GetCurrentClassLogger();

        static void RabbitMqListener()
        {
            using (var listener = new RabbitMqListener("MyQueue"))
            {
                listener.Listen(GetMessage);
            }
        }

        static async void RabbitMqMassControlSender()
        {
            var busControl = ConnectionFactoryResolver.CreateBusControl();

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            try
            {
                //var handle = busControl.ConnectConsumer<SubmitContactConsumer>();
                await busControl.StartAsync(source.Token);

                var endpoint = await busControl.GetSendEndpoint(new Uri("queue:contact-service"));

                await endpoint.Send<DBContact>(new DBContact()
                {
                    Id = 10000,
                    Name = nameof(DBContact),
                    Phone = "123456",
                    Status = 1
                });

                //Thread.Sleep(3000);
                Console.WriteLine("DBContact sended in queue");

                //handle.Disconnect();

            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
            }
            finally
            {
                await busControl.StopAsync();
            }
        }


        static async void RabbitMqMassControlListener()
        {
            var busControl = ConnectionFactoryResolver.CreateBusControl();

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            try
            {
                //var handle = busControl.ConnectConsumer<SubmitContactConsumer>();
                await busControl.StartAsync(source.Token);
                var contactChangeHandler = busControl.ConnectReceiveEndpoint("contact-service", e => {
                    e.Consumer<ReceiveContactConsumer>();
                });

                await contactChangeHandler.Ready;

                //Thread.Sleep(3000);
                Console.WriteLine("All Consumers");

                //handle.Disconnect();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                await busControl.StopAsync();
            }
        }

        static void Main(string[] args)
        {
            RabbitMqMassControlListener();

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        static void GetMessage(string msg)
        {
            Logger.Debug(msg);
            Console.WriteLine(msg);
        }
    }
}
