using FluentValidation;
using Shared.Extensions;

namespace Shared
{
    public class PagedAndSortedResultRequestDto<T> : PagedResultRequestDto where T : ISortableEntity
    {
        public string? Sorting { get; set; }
        public class SortingValidator<Request> : AbstractValidator<Request> where Request : PagedAndSortedResultRequestDto<T>
        {
            public SortingValidator()
            {
                RuleFor(x => x.Sorting)
                    .Must(s => T.GetSortingKeys().Any(x => x.Equals(s, StringComparison.OrdinalIgnoreCase)))
                    .When(x => !string.IsNullOrEmpty(x.Sorting))
                    .WithMessage($"Sorting key can only be one of the following values: {T.GetSortingKeys().Join()}");
            }

        }
    }
}