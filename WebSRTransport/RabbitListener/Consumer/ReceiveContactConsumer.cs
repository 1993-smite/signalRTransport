using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using DB.DBModels;
using System.Threading.Tasks;

namespace RabbitListener.Consumer
{
    public class ReceiveContactConsumer: IConsumer<DBContact>
    {
        public async Task Consume(ConsumeContext<DBContact> context)
        {
            Console.WriteLine($"{context.Message.Id} | {context.Message.Name} | {context.Message.Phone} | {context.Message.Status}");

            //throw new NotImplementedException();
        }
    }
}
