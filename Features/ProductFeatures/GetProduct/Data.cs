using Api.Persistence;
using static Api.Shared.IoC;

namespace Api.Features.ProductFeatures.GetProduct
{
    internal sealed class Data(StoreDbContext db) : IScoped
    {
        public Response? GetProductById(int id)
        {
            var response =
                db
                .Products
                .Select(x => new Response
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                })
                .FirstOrDefault(x => x.Id == id);
            return response;
        }
    }
}
