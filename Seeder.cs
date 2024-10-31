using GabiniBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace GabiniBackEnd
{
    public static class Seeder
    {
        public static async Task SeedAsync(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<GabiniBackEndDbContext>();

                await context.Database.MigrateAsync();

                if ( await context.Usuarios.AnyAsync() == false)
                {
                    var usuario1 = new Usuario
                    {
                        Id = "1",
                        NomeCompleto = "User One",
                        Email = "email1@email.com",
                        Telefone = "11987654321",
                        NomeDeUsuario = "user1",
                        Endereco = "Rua A, 123",
                        Cidade = "São Paulo",
                        Estado = "SP",
                        Cep = "12345-678",
                        Senha = "senha1",
                        DataNascimento = "1990-01-01",
                        Cpf = "12345678901",
                        Ativo = true,
                    };

                    var usuario2 = new Usuario
                    {
                        Id = "2",
                        NomeCompleto = "User Two",
                        Email = "email2@email.com",
                        Telefone = "21987654321",
                        NomeDeUsuario = "user2",
                        Endereco = "Rua B, 456",
                        Cidade = "Rio de Janeiro",
                        Estado = "RJ",
                        Cep = "23456-789",
                        Senha = "senha2",
                        DataNascimento = "1992, 2, 2",
                        Cpf = "23456789012",
                        Ativo = true
                    };

                    var usuario3 = new Usuario
                    {
                        Id = "3",
                        NomeCompleto = "User Three",
                        Email = "email3@email.com",
                        Telefone = "31987654321",
                        NomeDeUsuario = "user3",
                        Endereco = "Rua C, 789",
                        Cidade = "Belo Horizonte",
                        Estado = "MG",
                        Cep = "34567-890",
                        Senha = "senha3",
                        DataNascimento = "1994, 3, 3",
                        Cpf = "34567890123",
                        Ativo = true
                    };

                    await context.Usuarios.AddRangeAsync(usuario1, usuario2, usuario3);
                    await context.SaveChangesAsync();
                }

                if (await context.Produtos.AnyAsync() == false)
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
