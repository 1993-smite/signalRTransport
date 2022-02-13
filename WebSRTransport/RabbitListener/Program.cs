using NLog;
using RabbitCore.Core.Listeners;
using System;

namespace RabbitListener
{
    class Program
    {
        public static NLog.Logger Logger
            = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var listener = new RabbitMqListener("MyQueue");
            listener.Listen(GetMessage);


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
