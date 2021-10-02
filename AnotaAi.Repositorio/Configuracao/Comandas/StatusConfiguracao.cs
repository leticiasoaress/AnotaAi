using AnotaAi.Dominio.Entidades.Comandas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnotaAi.Repositorio.Configuracao
{
    public class StatusConfiguracao : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Descricao)
                   .IsRequired()
                   .HasMaxLength(150);
        }
    }
}
