namespace Core.Models
{
    public class Carrinho
    {
        public string Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime CarrinhoDate { get; set; }
        public List<Item> Produtos { get; set; } = new List<Item>();
        public double TotalAmount { get
            {
                return Produtos.Sum((produto) => produto.Quantity * produto.Produto.Price);
            } private set {}
        }

        private Carrinho() { }

        public Carrinho(Usuario usuario, List<Item> produtos, DateTime carrinhoDate)
        {
            Usuario = usuario;
            Produtos = produtos;
            CarrinhoDate = carrinhoDate;
        }
    }
}
