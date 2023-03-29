using Microsoft.AspNetCore.SignalR;

namespace WebShare.Hubs
{
    public class ShareHub : Hub
    {
        public async Task SendMessage(string connectionId, string url)
        {
            await Clients.Client(connectionId).SendAsync(url);
        }

        public string GetConnectionId() => Context.ConnectionId;
    }
}
