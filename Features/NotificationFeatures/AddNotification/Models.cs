namespace Api.Features.NotificationFeatures.AddNotification
{
    internal sealed class Request
    {
        public required string Message { get; set; }

        internal sealed class Validator : Validator<Request>
        {
            public Validator()
            {

            }
        }
    }

    internal sealed class Response
    {
        public required string Message { get; set; }
    }
}
