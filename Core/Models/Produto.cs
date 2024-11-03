namespace Core.Models
{
    public class Produto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public required string Image_url { get; set; }

        public Produto() { }

        public Produto(string id, string name, string description, double price, string image_url)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Image_url = image_url;
        }

        public Produto(string name, string description, double price, string image_url)
        {
            Name = name;
            Description = description;
            Price = price;
            Image_url = image_url;
        }
    }
}
