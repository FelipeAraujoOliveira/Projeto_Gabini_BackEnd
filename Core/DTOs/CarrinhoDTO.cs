using Core.DTOs;
namespace Core.DTOs
{
public class CarrinhoCreateDTO
{
    public string UsuarioId { get; set; }
    public ICollection<ProdutoItemDTO> ProdutosDTO { get; set; }
}

public class CarrinhoUpdateDTO
{
    public ICollection<ProdutoItemDTO> ProdutosDTO { get; set; }
}
}