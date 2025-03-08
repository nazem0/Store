using Api.Models;
using FastEndpoints;

namespace Api.Features.ProductFeatures.AddProduct
{
    internal sealed class Mapper : Mapper<Request, Response, Product>
    {
        public override Product ToEntity(Request r)
        {
            return new Product(r.Name, r.Price, r.Quantity);
        }

        public override Response FromEntity(Product e)
        {
            return new Response { Id = e.Id, Name = e.Name, Price = e.Price, Quantity = e.Quantity };
        }
    }
}