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



            //modelBuilder.Entity<Produto>().ToTable("Produtos");
            //modelBuilder.Entity<Produto>().Property(x => x.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Produto>().Property(x => x.Nome).HasMaxLength(120).HasColumnType("varchar(120)");
            //modelBuilder.Entity<Produto>().Property(x => x.Preco);
            //modelBuilder.Entity<Produto>().Property(x => x.PromocaoId);
            //modelBuilder.Entity<Produto>().HasOne(x => x.Promocao).WithMany(p => p.Produtos).HasForeignKey(x => x.PromocaoId);
            //modelBuilder.Entity<Produto>().Property(x => x.ValorTotal);

            //modelBuilder.Entity<Promocao>().ToTable("Promocoes");
            //modelBuilder.Entity<Promocao>().Property(p => p.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Promocao>().Property(p => p.Nome).HasMaxLength(120).HasColumnType("varchar(120)");
            //modelBuilder.Entity<Promocao>().Property(p => p.Quantidade);
            //modelBuilder.Entity<Promocao>().Property(p => p.PromocaoComValorFixo).HasColumnType("bit");
            //modelBuilder.Entity<Promocao>().Property(p => p.Valor);

            //modelBuilder.Entity<CarrinhoCompras>().ToTable("CarrinhoCompras");
            //modelBuilder.Entity<CarrinhoCompras>().Property(c => c.Id);
            //modelBuilder.Entity<CarrinhoCompras>().Property(c => c.ValorTotal);
            //modelBuilder.Entity<CarrinhoCompras>().Property(c => c.QuantidadeProdutos);

            //modelBuilder.Entity<CarrinhoCompras>().HasMany(c => c.Produtos).WithOne(p => p.CarrinhoCompras).HasForeignKey(p => p.CarrinhoComprasId);


        }

    }
}
