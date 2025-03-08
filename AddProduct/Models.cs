using Domain.Models;
using FastEndpoints;
using FluentValidation;

namespace AddProduct
{
    internal sealed class Request
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
        internal sealed class Validator : Validator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Name is required!")
                    .MaximumLength(ProductConstants.NameMaxLength)
                    .WithMessage($"Name cannot {ProductConstants.NameMaxLength} letters");

                RuleFor(x => x.Price)
                    .NotEmpty()
                    .WithMessage("Price is required!")
                    .GreaterThan(0)
                    .WithMessage("Price cannot be zero or negative!");

                RuleFor(x => x.Quantity)
                    .NotEmpty()
                    .WithMessage("Quantity is required!")
                    .GreaterThan(0)
                    .WithMessage("Quantity cannot be zero or negative!");

            }
        }
    }

    internal sealed class Response
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
    }
}
