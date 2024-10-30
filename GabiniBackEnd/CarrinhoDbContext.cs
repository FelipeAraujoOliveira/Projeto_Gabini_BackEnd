using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using ProjetoCarrinhoProdutos.Models;

namespace ProjetoCarrinhoProdutos;

public partial class CarrinhoDbContext : DbContext
{

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Carrinho> Carrinhos { get; set; }

    public CarrinhoDbContext()
    {
    }

    public CarrinhoDbContext(DbContextOptions<CarrinhoDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Usuario>().HasKey(c => c.Id);
        modelBuilder.Entity<Usuario>().Property(c => c.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Produto>().HasKey(c => c.Id);
        modelBuilder.Entity<Produto>().Property(c => c.Id).ValueGeneratedOnAdd();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
