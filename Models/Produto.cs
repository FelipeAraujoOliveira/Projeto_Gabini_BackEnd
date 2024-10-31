namespace ProjetoCarrinhoProdutos.Models
{
    public class Produto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public required float Preco { get; set; }
        public required int Quantidade { get; set; } 
        public string Image_url { get; set; }
    }
}
