using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    public class DummyHub : Hub<IDummyClient>
    {
        public readonly string _user;
        public DummyHub()
        {
            _user = Context?.User?.Identity?.Name ?? Context?.ConnectionId ?? "Guest";
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.ReceiveMessageAsync(_user, Context.ConnectionAborted);
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.ReceiveMessageAsync($"{_user}: {message}", Context.ConnectionAborted);
        }
    }
}
