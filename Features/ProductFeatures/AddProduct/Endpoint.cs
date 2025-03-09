using Api.Persistence;
using Api.Shared;

namespace Api.Features.ProductFeatures.AddProduct
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public required Data Data { get; set; }
        public required UnitOfWork UnitOfWork { get; set; }
        public override void Configure()
        {
            Post($"{FeaturesList.Products}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var entity = Map.ToEntity(r);
            Data.AddProduct(entity);
            await UnitOfWork.CommitAsync(c);
            await SendMapped(entity, ct: c);
        }
    }
}