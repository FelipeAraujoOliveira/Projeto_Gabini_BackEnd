using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProjetoCarrinhoProdutos.Models;

namespace ProjetoCarrinhoProdutos
{
    public static class Seeder
    {
        public static async Task SeedAsync(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CarrinhoDbContext>();

              
                await context.Database.MigrateAsync();

                
                if (!context.Usuarios.Any())
                {
                    
                    var usuario1 = new Usuario { Id = "1", Nome = "User1", Email = "email1@email.com", Senha = "senha1", Ativo = true };
                    var usuario2 = new Usuario { Id = "2", Nome = "User2", Email = "email2@email.com", Senha = "senha2", Ativo = true };
                    var usuario3 = new Usuario { Id = "3", Nome = "User3", Email = "email3@email.com", Senha = "senha3", Ativo = true };

                    await context.Usuarios.AddRangeAsync(usuario1, usuario2, usuario3);
                    await context.SaveChangesAsync();
                }

                
                if (!context.Produtos.Any())
                {
                    var produto1 = new Produto { Id = "1", Nome = "Produto1", Preco = 10.0f, Quantidade = 100, Image_url = "url_to_image1" };
                    var produto2 = new Produto { Id = "2", Nome = "Produto2", Preco = 20.0f, Quantidade = 200, Image_url = "url_to_image2" };
                    var produto3 = new Produto { Id = "3", Nome = "Produto3", Preco = 30.0f, Quantidade = 300, Image_url = "url_to_image3" };

                    await context.Produtos.AddRangeAsync(produto1, produto2, produto3);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
