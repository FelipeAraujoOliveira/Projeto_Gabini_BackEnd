namespace Core.Models
{
    public class Item
    {
        public required string Id { get; set; }
        public required Produto Produto { get; set; }
        public double Quantity { get; set; }
    }
}
