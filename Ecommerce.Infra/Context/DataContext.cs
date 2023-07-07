﻿using Ecommerce.Domain.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Produto>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Produto>().Property(x => x.Nome).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Produto>().Property(x => x.Preco);
            modelBuilder.Entity<Produto>().Property(x => x.PromocaoId);
            modelBuilder.Entity<Produto>().HasOne(x => x.Promocao).WithMany(p => p.Produtos).HasForeignKey(x => x.PromocaoId);

            modelBuilder.Entity<Promocao>().ToTable("Promocoes");
            modelBuilder.Entity<Promocao>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Promocao>().Property(p => p.Nome).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Promocao>().Property(p => p.QuantidadeProdutos);
            modelBuilder.Entity<Promocao>().Property(p => p.PromocaoComValorFixo).HasColumnType("bit");
            modelBuilder.Entity<Promocao>().Property(p => p.Valor);
        }

    }
}
