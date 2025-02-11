using System;
using Microsoft.AspNetCore.SignalR;

namespace Dealer.API.SignalR;

public class React : Hub
{
    public async Task Send(string user, string Messaje){
            await Clients.All.SendAsync("ReceiveMessage",user, Messaje);
    }
}
