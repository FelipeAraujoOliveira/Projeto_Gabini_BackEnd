namespace GabiniBackEnd.Models
{
    public class Usuario
    {
        public required string Id { get; set; }
        public string NomeCompleto { get; set; } 
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string NomeDeUsuario { get; set; } 
        public string Endereco { get; set; } 
        public string Cidade { get; set; } 
        public string Estado { get; set; } 
        public string Cep { get; set; } 
        public string Senha { get; set; } 
        public DateTime DataNascimento { get; set; } 
        public string Cpf { get; set; }
        public required bool Ativo {  get; set; }
        public string Url_foto_perfil { get; set; }


        public Usuario() { }

        public Usuario(string id, string nomeCompleto, string email, string telefone, string nomeDeUsuario, string endereco, string cidade, string estado, string cep, string senha, DateTime dataNascimento, string cpf, bool ativo, string url_foto_perfil)
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
