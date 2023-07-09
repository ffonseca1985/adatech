using AdaTech.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdaTech.Infra.Data.Repository.Maps
{
    public class CardEntityConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            // Set primary key
            builder.HasKey(c => c.Id);

            // Configure other properties
            builder.Property(c => c.Titulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Disable)
                .IsRequired();

            builder.Property(c => c.Conteudo)
                .HasMaxLength(500);

            builder.Property(c => c.Lista)
                .HasMaxLength(1000);
        }
    }
}
