using Core.DTOs;

namespace Core.DTOs
{
public class CreateUsuarioRequest
{
    public required UsuarioDTO Usuario { get; set; }
    public required EnderecoDTO Endereco { get; set; }
}
}