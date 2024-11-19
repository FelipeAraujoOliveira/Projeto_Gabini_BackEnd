namespace Core.DTOs
{
    public class UsuarioDTO
    {
        public required string NomeCompleto { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string Cpf { get; set; }
        public required string Telefone { get; set; }
        public required string NomeDeUsuario { get; set; }
        public required string Url_foto_perfil { get; set; }
    }
}
