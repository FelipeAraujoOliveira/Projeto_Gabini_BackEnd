using Core.Models;
using Core.DTOs;
using Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Services;

namespace Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<EnderecoDTO> GetEnderecoById(string id)
        {
            var endereco = await _enderecoRepository.GetEndereco(id);
            if (endereco == null)
            {
                throw new Exception("Endereço não encontrado");
            }

            return new EnderecoDTO
            {
                Id = endereco.Id,
                Rua = endereco.Rua,
                Numero = endereco.Numero,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                Cep = endereco.Cep,
                UsuarioId = endereco.UsuarioId
            };
        }

        public async Task<IEnumerable<EnderecoDTO>> GetAllEnderecos()
        {
            var enderecos = await _enderecoRepository.GetAllEnderecos();
            return enderecos.Select(endereco => new EnderecoDTO
            {
                Id = endereco.Id,
                Rua = endereco.Rua,
                Numero = endereco.Numero,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                Cep = endereco.Cep,
                UsuarioId = endereco.UsuarioId
            });
        }

        public async Task<Endereco> CreateEndereco(Endereco endereco)
        {
            return await _enderecoRepository.CreateEndereco(endereco);
        }

        public async Task<Endereco> UpdateEndereco(string id, Endereco endereco)
        {
            return await _enderecoRepository.UpdateEndereco(id, endereco);
        }

        public async Task<bool> DeleteEndereco(string id)
        {
            return await _enderecoRepository.DeleteEndereco(id);
        }
    }
}
