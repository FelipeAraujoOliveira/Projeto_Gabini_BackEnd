using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly CarrinhosDbContext _context;

        public EnderecoRepository(CarrinhosDbContext context)
        {
            _context = context;
        }

        public async Task<Endereco?> GetEndereco(string id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task<IEnumerable<Endereco>> GetAllEnderecos()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<Endereco> CreateEndereco(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> UpdateEndereco(string id, Endereco endereco)
        {
            var existingEndereco = await GetEndereco(id);
            if (existingEndereco == null)
            {
                throw new Exception("Endereço não encontrado");
            }

            existingEndereco.Rua = endereco.Rua;
            existingEndereco.Numero = endereco.Numero;
            existingEndereco.Cidade = endereco.Cidade;
            existingEndereco.Estado = endereco.Estado;
            existingEndereco.Cep = endereco.Cep;

            await _context.SaveChangesAsync();
            return existingEndereco;
        }

        public async Task<bool> DeleteEndereco(string id)
        {
            var endereco = await GetEndereco(id);
            if (endereco == null)
            {
                return false;
            }

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
