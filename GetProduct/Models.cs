namespace GetProduct
{
    internal sealed class Request
    {
        public int Id { get; set; }
    }
    internal sealed class Response
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
    }
}