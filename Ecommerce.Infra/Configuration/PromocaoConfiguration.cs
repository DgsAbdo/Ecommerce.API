using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infra.Configuration
{
    internal class PromocaoConfiguration : IEntityTypeConfiguration<Promocao>
    {
        public void Configure(EntityTypeBuilder<Promocao> builder)
        {
            builder.ToTable(nameof(Promocao));
            builder.HasKey(x => x.Id);

            builder.HasData(new Promocao(1,"3 por R$10,00", true, 3, 10));
            builder.HasData(new Promocao(2,"Leve 2 e Pague 1", false, 2, 1));
        }
    }
}
