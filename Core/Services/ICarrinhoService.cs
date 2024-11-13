using Core.DTOs;
using Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core.Services
{
    public interface ICarrinhoService
    {
        Task<Carrinho> SaveCarrinho(string usuarioId, ICollection<ProdutoItemDTO> produtosDTO);
        Task<Carrinho> GetCarrinhoById(string id);
        Task<IEnumerable<Carrinho>> GetAllCarrinhos();
        Task<Carrinho> UpdateCarrinho(string id, CarrinhoUpdateDTO carrinhoDto);
        Task<bool> DeleteCarrinho(string id);
    }
}
