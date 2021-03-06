using RabbitCore.Core.Listeners;
using Microsoft.AspNetCore.SignalR;
using WebSRTransport.Hubs;
using System.Threading.Tasks;

namespace WebSRTransport.Services
{
    public class CommonRabbitMqSignalRService : RabbitMqListenerService
    {
        IHubContext<CommonHub> _hubContext;

        public static NLog.Logger Logger
            = NLog.Web
            .NLogBuilder
            .ConfigureNLog("nlog.config")
            .GetCurrentClassLogger();

        public CommonRabbitMqSignalRService(IHubContext<CommonHub> hubContext, string queue = null) : base(queue)
        {
            _hubContext = hubContext;
            Receiver += Receive;
        }

        public void Receive(string msg)
        {
            Logger.Info(msg);

            var task = Task.Run(async () => await _hubContext.Clients.All.SendAsync("Send", msg));
        }

    }
}
