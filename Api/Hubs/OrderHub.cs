using Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

public class OrderHub : Hub<IOrderHubClient>
{
    //public async Task SendMessage(string user, string message)
    //{
    //    await Clients.All.SendAsync("ReceiveMessage", user, message);
    //}

    //public override async Task OnConnectedAsync()
    //{
    //    var user = userContext.GetCurrentUser();

    //    if (user != null)
    //    {
    //        await Groups.AddToGroupAsync(Context.ConnectionId, user.UserId);
    //    }

    //    await base.OnConnectedAsync();
    //}

    //public override async Task OnDisconnectedAsync(Exception? exception)
    //{
    //    var user = userContext.GetCurrentUser();
    //    if (user != null)
    //    {
    //        await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.UserId);
    //    }
    //    await base.OnDisconnectedAsync(exception);
    //}
}
