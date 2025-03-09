namespace Api.Hubs
{
    public interface IDummyClient
    {
        public Task ReceiveMessageAsync(string message, CancellationToken c = default);
    }
}
