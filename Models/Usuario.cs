namespace ProjetoCarrinhoProdutos.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string NomeCompleto { get; set; } // fullName
        public string Email { get; set; }
        public string Telefone { get; set; } // phone
        public string NomeDeUsuario { get; set; } // username
        public string Endereco { get; set; } // address
        public string Cidade { get; set; } // city
        public string Estado { get; set; } // state
        public string Cep { get; set; } // zip
        public string Senha { get; set; } // password
        public string DataNascimento { get; set; } // birthDate
        public string Cpf { get; set; }
        public required bool Ativo {  get; set; }
        public string Url_foto_perfil { get; set; }


        public Usuario() { }

        public Usuario(string id, string nomeCompleto, string email, string telefone, string nomeDeUsuario, string endereco, string cidade, string estado, string cep, string senha, string dataNascimento, string cpf, bool ativo, string url_foto_perfil)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Email = email;
            Telefone = telefone;
            NomeDeUsuario = nomeDeUsuario;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            Url_foto_perfil = url_foto_perfil;
            Cep = cep;
            Senha = senha;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Ativo = ativo;

        }
    }
}
