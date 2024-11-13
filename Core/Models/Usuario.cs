using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Usuario
    {
        public required string Id { get; set; } = Guid.NewGuid().ToString();
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public required bool Ativo { get; set; }
        public string Url_foto_perfil { get; set; }

        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();

        public Usuario() { }

        public Usuario(string id, string nomeCompleto, string email, string telefone, string nomeDeUsuario, string senha, DateTime dataNascimento, string cpf, bool ativo, string url_foto_perfil)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Email = email;
            Telefone = telefone;
            NomeDeUsuario = nomeDeUsuario;
            Senha = senha;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Ativo = ativo;
            Url_foto_perfil = url_foto_perfil;
        }

        public Usuario(string nomeCompleto, string email, string telefone, string nomeDeUsuario, string senha, DateTime dataNascimento, string cpf, bool ativo, string url_foto_perfil)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Telefone = telefone;
            NomeDeUsuario = nomeDeUsuario;
            Senha = senha;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Ativo = ativo;
            Url_foto_perfil = url_foto_perfil;
        }
    }
}
