using ProjetoCarrinhoProdutos.Models;
using ProjetoCarrinhoProdutos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCarrinhoProdutos.Services
{
    public class CarrinhoService
    {
        private readonly CarrinhoRepository _carrinhoRepository;

        public CarrinhoService(CarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<Carrinho> ObterCarrinhoPorId(string idCarrinho)
        {
            Carrinho? carrinho = await _carrinhoRepository.ObterCarrinhoPorId(idCarrinho);
            if (carrinho == null)
            {
                throw new Exception("Carrinho não encontrado");
            }
            return carrinho;
        }

        public async Task<IEnumerable<Carrinho>> ObterTodosCarrinhos()
        {
            return await _carrinhoRepository.ObterTodos();
        }

        public async Task CriarCarrinho(Carrinho carrinho)
        {
            if (carrinho == null || string.IsNullOrWhiteSpace(carrinho.UsuarioId))
            {
                throw new ArgumentNullException(nameof(carrinho), "Carrinho ou usuário não podem ser nulos.");
            }

            await _carrinhoRepository.Adicionar(carrinho);
        }

        public async Task AtualizarCarrinho(string idCarrinho, Carrinho carrinhoAtualizado)
        {
            if (carrinhoAtualizado == null)
            {
                throw new ArgumentNullException(nameof(carrinhoAtualizado), "Carrinho atualizado não pode ser nulo.");
            }

            await _carrinhoRepository.Atualizar(idCarrinho, carrinhoAtualizado);
        }

        public async Task DeletarCarrinho(string idCarrinho)
        {
            await _carrinhoRepository.Deletar(idCarrinho);
        }

        public void AdicionarProduto(Carrinho carrinho, Produto produto)
        {
            if (carrinho == null || produto == null)
            {
                throw new ArgumentNullException(nameof(carrinho), "Carrinho ou produto não podem ser nulos.");
            }

            carrinho.Produtos.Add(produto);
            carrinho.PrecoTotal += produto.Preco;
        }

        public void RemoverProduto(Carrinho carrinho, string idProduto)
        {
            if (carrinho == null)
            {
                throw new ArgumentNullException(nameof(carrinho), "Carrinho não pode ser nulo.");
            }

            var produto = carrinho.Produtos.FirstOrDefault(p => p.Id == idProduto);
            if (produto != null)
            {
                carrinho.Produtos.Remove(produto);
                carrinho.PrecoTotal -= produto.Preco;
            }
        }
    }
}
