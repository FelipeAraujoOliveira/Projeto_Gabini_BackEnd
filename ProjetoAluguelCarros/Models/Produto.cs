namespace ProjetoCarrinhoProdutos.Models
{
    public class Produto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; } 
        public string Image_url { get; set; }
    }
}
