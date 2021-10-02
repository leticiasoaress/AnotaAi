using AnotaAi.Dominio.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnotaAi.Repositorio.Configuracao
{
    public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(15,2)");

            builder.HasOne(p => p.Categoria);
        }
    }
}