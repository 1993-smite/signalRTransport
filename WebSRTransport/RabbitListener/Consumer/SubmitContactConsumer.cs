using DB.DBModels;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace RabbitListener.Consumer
{
    public class SubmitContactConsumer :
        IConsumer<DBContact>
    {
        public async Task Consume(ConsumeContext<DBContact> context)
        {
            var res = 3;

            //await context.Publish<DBContact>(new
            //{
            //    context.Message.Id
            //});
        }
    }
}
