using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Infrastructure;

public partial class CarrinhosDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Carrinho> Carrinhos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    public CarrinhosDbContext(DbContextOptions<CarrinhosDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
        .HasCharSet("utf8mb4");

        modelBuilder.Entity<Usuario>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Usuario>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Carrinho>()
            .HasKey(o => o.Id);
        modelBuilder.Entity<Carrinho>()
            .Property(o => o.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Item>()
            .HasKey(oi => oi.Id);
        modelBuilder.Entity<Item>()
            .Property(oi => oi.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Produto>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Produto>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        OnModelCreatingPartial(modelBuilder);
    }



    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
