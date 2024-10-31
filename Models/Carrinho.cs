using System;
using System.Collections.Generic;

namespace GabiniBackEnd.Models
{
    public class Carrinho
    {
        public required string Id { get; set; }
        public required string UsuarioId { get; set; }
        public List<Produto> Produtos { get; set; }
        public required DateTime DataCompra { get; set; }
        public required float PrecoTotal { get; set; }

        public Carrinho()
        {
            Produtos = new List<Produto>();
            DataCompra = DateTime.Now;
        }
    }
}
