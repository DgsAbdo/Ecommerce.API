using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Promocao> Promocao { get; set; }
        public DbSet<CarrinhoCompras> Carrinho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Preco).IsRequired();
            modelBuilder.Entity<Produto>().HasOne(p => p.Promocao).WithMany(p => p.Produtos).HasForeignKey(p => p.PromocaoId);

            modelBuilder.Entity<Promocao>().ToTable("Promocoes");
            modelBuilder.Entity<Promocao>().HasKey(p => p.Id);
            modelBuilder.Entity<Promocao>().Property(p => p.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Promocao>().Property(p => p.PromocaoComValorFixo).IsRequired();
            modelBuilder.Entity<Promocao>().Property(p => p.Quantidade).IsRequired();
            modelBuilder.Entity<Promocao>().Property(p => p.Valor).IsRequired();
            modelBuilder.Entity<Promocao>().HasMany(p => p.Produtos).WithOne(pr => pr.Promocao).HasForeignKey(pr => pr.PromocaoId);

            modelBuilder.Entity<CarrinhoCompras>().ToTable("CarrinhoCompras");
            modelBuilder.Entity<CarrinhoCompras>().HasKey(c => c.Id);
            modelBuilder.Entity<CarrinhoCompras>().Property(c => c.ValorTotal).IsRequired();

            modelBuilder.Entity<ItemCarrinho>().ToTable("ItensCarrinho");
            modelBuilder.Entity<ItemCarrinho>().HasKey(ic => ic.Id);
            modelBuilder.Entity<ItemCarrinho>().HasOne(ic => ic.Produto).WithMany(p => p.ItensCarrinho).HasForeignKey(ic => ic.ProdutoId);
            modelBuilder.Entity<ItemCarrinho>().HasOne(ic => ic.CarrinhoCompras).WithMany(cc => cc.ItensCarrinho).HasForeignKey(ic => ic.CarrinhoComprasId);
        }

    }
}
