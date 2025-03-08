using Domain.Models;
using Persistence;
using static Shared.IoC;

namespace AddProduct
{
    internal sealed class Data(StoreDbContext db) : IScoped
    {
        public void AddProduct(Product e)
        {
            db.Products.Add(e);
        }
    }
}
