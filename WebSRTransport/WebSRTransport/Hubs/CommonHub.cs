using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSRTransport.Hubs
{
    public static class HubConstant
    {
        public static string GroupKey => "group";
    }

    public class CommonHub: Hub
    {
        public async Task Send(string message, string group = "")
        {
            if (string.IsNullOrWhiteSpace(group))
                await this.Clients.All.SendAsync("Send", message);
            else
                await this.Clients.Group(group).SendAsync("Send", message);
        }

        public override async Task OnConnectedAsync()
        {
            var group = Context.GetHttpContext().Request.Query[HubConstant.GroupKey];

            string value = !string.IsNullOrEmpty(group.ToString()) ? group.ToString() : "default";
            await Groups.AddToGroupAsync(Context.ConnectionId, value);
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
