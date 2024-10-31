using GabiniBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace GabiniBackEnd;

public partial class GabiniBackEndDbContext : DbContext
{

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Carrinho> Carrinhos { get; set; }

    public GabiniBackEndDbContext()
    {
    }

    public GabiniBackEndDbContext(DbContextOptions<GabiniBackEndDbContext> options)
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
