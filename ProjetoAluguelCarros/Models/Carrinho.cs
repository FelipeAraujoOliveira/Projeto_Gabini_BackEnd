using System;
using System.Collections.Generic;

namespace ProjetoCarrinhoProdutos.Models
{
    public class Carrinho
    {
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public List<Produto> Produtos { get; set; }
        public DateTime DataCompra { get; set; }
        public float PrecoTotal { get; set; }

        public Carrinho()
        {
            Produtos = new List<Produto>();
            DataCompra = DateTime.Now;
        }
    }
}
