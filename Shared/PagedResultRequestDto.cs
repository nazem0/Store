namespace Api.Shared
{
    public class PagedResultRequestDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public class PaginationValidator<Request> : AbstractValidator<Request> where Request : PagedResultRequestDto
        {
            public PaginationValidator()
            {
                RuleFor(x => x.Page)
                    .GreaterThanOrEqualTo(1)
                    .LessThanOrEqualTo(int.MaxValue);

                RuleFor(x => x.PageSize)
                    .GreaterThanOrEqualTo(1)
                    .LessThanOrEqualTo(20);
            }
        }
    }
}