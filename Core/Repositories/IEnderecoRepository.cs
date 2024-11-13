using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IEnderecoRepository
    {
        Task<Endereco?> GetEndereco(string id);
        Task<IEnumerable<Endereco>> GetAllEnderecos();
        Task<Endereco> CreateEndereco(Endereco endereco);
        Task<Endereco> UpdateEndereco(string id, Endereco endereco);
        Task<bool> DeleteEndereco(string id);
    }
}
