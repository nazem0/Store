using Domain.Models;
using FluentValidation;
using Shared;
using System.Linq.Dynamic.Core;

namespace GetProducts
{
    internal sealed class Request : PagedAndSortedResultRequestDto<Product>
    {
        public string? Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        internal sealed class Validator : SortingValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.MaxPrice)
                    .GreaterThan(x => x.MinPrice)
                    .When(x => x.MinPrice.HasValue)
                    .WithMessage("Maximum price cannot be less than minimum price");
            }
        }
    }

    internal sealed class Response
    {
        public PagedResult<ProductListDto> Products { get; set; } = new();
    }
    internal sealed class ProductListDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
    }
}
