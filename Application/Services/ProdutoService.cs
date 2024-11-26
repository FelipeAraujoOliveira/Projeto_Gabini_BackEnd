using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IImageService _imageService;

        public ProdutoService(IProdutoRepository produtoRepository, IImageService imageService)
        {
            _produtoRepository = produtoRepository;
            _imageService = imageService;
        }

        public async Task<List<Produto>> GetProdutos(List<string> produtosIds)
        {
            return await _produtoRepository.GetProdutos(produtosIds);
        }

        public async Task<List<Produto>> GetAllProdutos()
        {
            return await _produtoRepository.GetAllProdutos();
        }

        public async Task Add(Produto produto)
        {
            await _produtoRepository.Add(produto);
        }

        public async Task<Produto> GetProdutoById(string id)
        {
            return await _produtoRepository.GetProdutoById(id);
        }

        public async Task<string> UploadProductImage(string productId, FileData file)
        {
            
            Produto produto = await GetProdutoById(productId);

            string uploadedFileUrl = await _imageService.UploadImage(file, "produtos", productId);

            produto.Image_url = uploadedFileUrl;

            await _produtoRepository.Update(produto);

            return uploadedFileUrl;
        }

    }
}
