using AnotaAi.Dominio.Entidades.Comandas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnotaAi.Repositorio.Configuracao
{
    public class ComandaConfiguracao : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NumeroMesa)
                   .IsRequired();

            builder.Property(c => c.NomeCliente)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.ValorTotal)
                   .IsRequired()
                   .HasColumnType("decimal(15,2)");

            builder.Property(c => c.ValorDesconto)
                   .IsRequired()
                   .HasColumnType("decimal(15,2)");

            builder.Property(c => c.ValorPago)
                   .IsRequired()
                   .HasColumnType("decimal(15,2)");

            builder.HasOne(c => c.Status);

            builder.HasOne(c => c.Usuario);
        }
    }
}