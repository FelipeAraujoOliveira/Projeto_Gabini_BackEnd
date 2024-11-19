using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class EnderecoDTO
    {

        [Required]
        public required string Rua { get; set; }

        [Required]
        public required string Numero { get; set; }

        [Required]
        public required string Cidade { get; set; }

        [Required]
        public required string Estado { get; set; }
        
        
        public string Complemento { get; set; }

        [Required]
        public required string Cep { get; set; }


    }
}
