using Api.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Api.Features.NotificationFeatures.AddNotification
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public IHubContext<DummyHub, IDummyClient> _hubContext;
        public Endpoint(IHubContext<DummyHub, IDummyClient> hubContext)
        {
            _hubContext = hubContext;
        }
        public override void Configure()
        {
            Post(FeaturesList.Notifications);
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {

            await _hubContext.Clients.All.ReceiveMessageAsync(r.Message, c);
            await SendOkAsync(new Response() { Message = r.Message }, c);
        }
    }
}