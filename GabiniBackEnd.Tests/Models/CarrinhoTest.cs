using System;
using System.Collections.Generic;
using Xunit;
using GabiniBackEnd.Models;

namespace GabiniBackEnd.Tests.Models
{
    public class CarrinhoTests
    {
        [Fact]
        public void Carrinho_Initialization_ShouldSetDefaultValues()
        {
            // Arrange & Act
            var carrinho = new Carrinho
            {
                Id = "123",
                UsuarioId = "usuario123",
                DataCompra = DateTime.Now,
                PrecoTotal = 0.0f
            };

            // Assert
            Assert.NotNull(carrinho.Produtos);
            Assert.Empty(carrinho.Produtos);
            Assert.Equal(DateTime.Now.Date, carrinho.DataCompra.Date); // Comparação de data sem a hora
        }

        [Fact]
        public void Carrinho_SetProperties_ShouldUpdateValues()
        {
            // Arrange
            var carrinho = new Carrinho
            {
                Id = "123",
                UsuarioId = "usuario123",
                DataCompra = DateTime.Now,
                PrecoTotal = 99.99f
            };

            // Act & Assert
            Assert.Equal("123", carrinho.Id);
            Assert.Equal("usuario123", carrinho.UsuarioId);
            Assert.Equal(99.99f, carrinho.PrecoTotal);
        }
    }
}
