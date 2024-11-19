using Core.DTOs;

namespace Core.DTOs
{
public class CreateUsuarioRequest
{
    public UsuarioDTO Usuario { get; set; }
    public EnderecoDTO Endereco { get; set; }
}
}