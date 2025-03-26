namespace Api.Features.ProductFeatures.GetProducts
{
    internal sealed class Endpoint : Endpoint<Request, Response>
    {
        public required Data Data { get; set; }
        public override void Configure()
        {
            Get($"{FeaturesList.Products}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {

            var response = Data.GetProducts(r);
            await SendOkAsync(response, c);
        }
    }
}