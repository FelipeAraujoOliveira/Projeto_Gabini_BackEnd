using Core.Models;
using Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IEnderecoService
    {
        Task<EnderecoDTO> GetEnderecoById(string id);
        Task<IEnumerable<EnderecoDTO>> GetAllEnderecos();
        Task<Endereco> CreateEndereco(Endereco endereco);
        Task<Endereco> UpdateEndereco(string id, Endereco endereco);
        Task<bool> DeleteEndereco(string id);
    }
}
