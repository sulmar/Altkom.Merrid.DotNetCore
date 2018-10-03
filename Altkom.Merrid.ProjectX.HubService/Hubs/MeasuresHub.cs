using Altkom.Merrid.ProjectX.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.Merrid.ProjectX.HubService.Hubs
{
    public class MeasuresHub : Hub
    {
        public Task Send(Measure measure)
        {
            return Clients.All.SendAsync("Send", measure);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
