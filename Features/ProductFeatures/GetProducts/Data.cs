using Api.Models;
using Api.Persistence;
using Api.Shared;
using System.Linq.Dynamic.Core;

namespace Api.Features.ProductFeatures.GetProducts
{
    internal sealed class Data(StoreDbContext db) : IoC.IScoped
    {
        public Response GetProducts(Request input)
        {
            //Filter
            var products =
                db.Products.AsQueryable()
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name!))
                .WhereIf(input.MinPrice.HasValue, x => x.Price >= input.MinPrice)
                .WhereIf(input.MaxPrice.HasValue, x => x.Price <= input.MaxPrice);
            //Order
            bool isSuitableOrderingKey =
                !string.IsNullOrWhiteSpace(input.Sorting) &&
                Product.GetSortingKeys().Any(x => x.Equals(input.Sorting, StringComparison.OrdinalIgnoreCase));
            if (isSuitableOrderingKey)
            {
                products = products.OrderBy(input.Sorting!);
            }
            else
            {
                products = products.OrderByDescending(x => x.Id);
            }
            //Projection
            var list =
                products
                .Select
                (e => new ProductListDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    Quantity = e.Quantity
                });
            //Pagination
            return new() { Products = list.PageResult(input.Page, input.PageSize) };
        }
    }
}
