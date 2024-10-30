using System.Xml.Linq;

namespace ProjetoCarrinhoProdutos.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string Senha { get; set; }

        public Usuario() { }

        public Usuario(string id, string nome, string? email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public Usuario(string nome, string senha, string? email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
