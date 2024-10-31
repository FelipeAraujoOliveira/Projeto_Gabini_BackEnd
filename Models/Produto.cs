namespace GabiniBackEnd.Models
{
    public class Produto
    {
        public required string Id { get; set; }
        public required string Nome { get; set; }
        public required float Preco { get; set; }
        public required int Quantidade { get; set; } 
        public required string Image_url { get; set; }
    }
}
