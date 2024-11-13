using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class EnderecoDTO
    {

        [Required]
        public string Rua { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }
        
        public string Complemento { get; set; }

        [Required]
        public string Cep { get; set; }


    }
}
