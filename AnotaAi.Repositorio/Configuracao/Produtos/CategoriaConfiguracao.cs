using AnotaAi.Dominio.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnotaAi.Repositorio.Configuracao
{
    public class CategoriaConfiguracao : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.Descricao)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Ativo)
                   .IsRequired();
        }
    }
}