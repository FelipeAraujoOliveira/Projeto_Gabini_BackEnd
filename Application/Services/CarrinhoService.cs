using Application.Services;
using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IProdutoService _produtoService;
        private readonly ICarrinhoRepository _carrinhoRepository;

        public CarrinhoService(
            IUsuarioService usuarioService,
            IProdutoService produtoService,
            ICarrinhoRepository carrinhoRepository
        )
        {
            _usuarioService = usuarioService;
            _produtoService = produtoService;
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<Carrinho> SaveCarrinho(string usuarioId, ICollection<ProdutoItemDTO> produtosDTO)
        {
            Usuario usuario = await _usuarioService.GetUsuarioOrThrowException(usuarioId);
            List<Produto> produtos = await _produtoService.GetProdutos(produtosDTO.Select(pi => pi.ProdutoId).ToList());

            List<Item> carrinhoItems = produtosDTO
                .Select(pi => new Item { Produto = produtos.First(p => p.Id == pi.ProdutoId), Quantity = pi.Quantity })
                .ToList();

            Carrinho carrinho = new Carrinho(
                usuario: usuario,
                produtos: carrinhoItems,
                carrinhoDate: DateTime.Now
            );

            return await _carrinhoRepository.SaveCarrinho(carrinho);
        }

        public async Task<Carrinho> GetCarrinhoById(string id)
        {
            return await _carrinhoRepository.GetCarrinhoById(id);
        }

        public async Task<IEnumerable<Carrinho>> GetAllCarrinhos()
        {
            return await _carrinhoRepository.GetAllCarrinhos();
        }

        public async Task<Carrinho> UpdateCarrinho(string id, CarrinhoUpdateDTO carrinhoDto)
        {
            var carrinho = await _carrinhoRepository.GetCarrinhoById(id);
            if (carrinho == null) return null;

            List<Item> updatedItems = carrinhoDto.Produtos
                .Select(pi => new Item { Produto = carrinho.Produtos.First(p => p.Produto.Id == pi.ProdutoId).Produto, Quantity = pi.Quantity })
                .ToList();

            carrinho.Produtos = updatedItems;
            return await _carrinhoRepository.SaveCarrinho(carrinho);
        }

        public async Task<bool> DeleteCarrinho(string id)
        {
            return await _carrinhoRepository.DeleteCarrinho(id);
        }
    }
}
