using AnotaAi.Dominio.Entidades.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnotaAi.Repositorio.Configuracao
{
    public class CargoConfiguracao : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.Descricao)
                   .IsRequired()
                   .HasMaxLength(150);
        }
    }
}