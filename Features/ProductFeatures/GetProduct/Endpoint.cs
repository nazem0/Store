using Api.Shared;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Api.Features.ProductFeatures.GetProduct
{
    internal sealed class Endpoint : Endpoint<Request, Response>
    {
        public required Data Data { get; set; }
        public override void Configure()
        {
            Get($"{FeaturesList.Products}/{{id}}");
            AllowAnonymous();
            Description
            (x =>
            {
                x.ProducesProblemFE(StatusCodes.Status404NotFound);
            });
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            Response? product = Data.GetProductById(r.Id);
            if (product == null) await SendNotFoundAsync(c);
            else await SendOkAsync(product, c);
        }
    }
}