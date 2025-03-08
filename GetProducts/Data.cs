using Domain.Models;
using Persistence;
using Shared;
using System.Linq.Dynamic.Core;

namespace GetProducts
{
    internal sealed class Data(StoreDbContext db) : IoC.IScoped
    {
        public class GetProductsParams
        {
            public string? Name { get; set; }
            public decimal? MinPrice { get; set; }
            public decimal? MaxPrice { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
            public string Sorting { get; set; } = Product.GetSortingKeys().First();
        }
        public Response GetProducts(GetProductsParams input)
        {
            //Filter
            var products =
                db.Products.AsQueryable()
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name!))
                .WhereIf(input.MinPrice.HasValue, x => x.Price >= input.MinPrice)
                .WhereIf(input.MaxPrice.HasValue, x => x.Price <= input.MaxPrice);
            //Order
            if (Product.GetSortingKeys().Any(x => x.Equals(input.Sorting, StringComparison.OrdinalIgnoreCase)))
            {
                products = products.OrderBy(input.Sorting);
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
