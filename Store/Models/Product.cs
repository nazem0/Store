using Api.Shared;

namespace Api.Models
{
    public class Product : ISortableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; private set; }
        public float Quantity { get; private set; }

        public Product(string name, decimal price, float quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public static string[] GetSortingKeys()
        {
            return [nameof(Id), nameof(Name), nameof(Price), nameof(Quantity)];
        }
    }

    public static class ProductConstants
    {
        public const int NameMaxLength = 20;
    }
}
