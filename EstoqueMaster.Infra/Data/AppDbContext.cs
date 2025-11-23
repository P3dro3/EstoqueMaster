using EstoqueMaster.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstoqueMaster.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações do Produto
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nome).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Descricao).HasMaxLength(1000);
                entity.Property(p => p.Categoria).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Custo).HasColumnType("decimal(18,2)");
                entity.Property(p => p.PrecoVenda).HasColumnType("decimal(18,2)");
                entity.Property(p => p.Codigo).IsRequired().HasMaxLength(50);
                entity.HasIndex(p => p.Codigo).IsUnique();
            });
        }
    }
}