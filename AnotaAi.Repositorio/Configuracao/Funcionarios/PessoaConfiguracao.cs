using AnotaAi.Dominio.Entidades.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnotaAi.Repositorio.Configuracao
{
    public class PessoaConfiguracao : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.CPF)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(p => p.DataNascimento)
                   .IsRequired();

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.CEP)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(p => p.Estado)
                   .IsRequired()
                   .HasMaxLength(2);

            builder.Property(p => p.Cidade)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Logradouro)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Numero)
                   .IsRequired()
                   .HasMaxLength(25);
        }
    }
}