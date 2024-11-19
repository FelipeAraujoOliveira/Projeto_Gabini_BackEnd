using Core.DTOs;
namespace Core.DTOs
{
public class CarrinhoCreateDTO
{
    public required string UsuarioId { get; set; }
    public required ICollection<ProdutoItemDTO> ProdutosDTO { get; set; }
}

public class CarrinhoUpdateDTO
{
    public required ICollection<ProdutoItemDTO> ProdutosDTO { get; set; }
}
}