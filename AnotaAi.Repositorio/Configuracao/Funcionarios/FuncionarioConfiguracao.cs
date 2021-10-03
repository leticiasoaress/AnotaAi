using AnotaAi.Dominio.Entidades.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnotaAi.Repositorio.Configuracao
{
    public class FuncionarioConfiguracao : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.DataContratacao)
                   .IsRequired();

            builder.HasOne(f => f.Cargo);

            builder.HasOne(f => f.Pessoa);
        }
    }
}
