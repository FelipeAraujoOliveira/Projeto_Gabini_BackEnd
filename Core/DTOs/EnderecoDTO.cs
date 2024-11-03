using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class EnderecoDTO
    {
        public string Id { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Cep { get; set; }

        public string UsuarioId { get; set; }
    }
}
