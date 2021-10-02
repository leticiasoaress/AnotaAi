using AnotaAi.Dominio.Entidades.Comandas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnotaAi.Repositorio.Configuracao
{
    public class ItemComandaConfiguracao : IEntityTypeConfiguration<ItemComanda>
    {
        public void Configure(EntityTypeBuilder<ItemComanda> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Quantidade)
                   .IsRequired();

            builder.HasOne(i => i.Produto);

            builder.HasOne(i => i.Comanda);
        }
    }
}
