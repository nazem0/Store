using Api.Models;
using Api.Persistence;
using static Api.Shared.IoC;

namespace Api.Features.ProductFeatures.AddProduct
{
    internal sealed class Data(StoreDbContext db) : IScoped
    {
        public void AddProduct(Product e)
        {
            db.Products.Add(e);
        }
    }
}
