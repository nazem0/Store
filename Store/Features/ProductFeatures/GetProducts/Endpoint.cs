using Api.Shared;
using FastEndpoints;

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

            var response = Data.GetProducts(new Data.GetProductsParams
            {
                MaxPrice = r.MaxPrice,
                MinPrice = r.MinPrice,
                Name = r.Name,
                Page = r.Page,
                PageSize = r.PageSize,
                Sorting = r.Sorting
            });
            await SendOkAsync(response, c);
        }
    }
}