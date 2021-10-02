using AnotaAi.Dominio.Entidades.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnotaAi.Repositorio.Configuracao
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Login)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Senha)
                   .IsRequired()
                   .HasMaxLength(400);

            builder.Property(u => u.IsMaster)
                   .IsRequired();

            builder.Property(u => u.Ativo)
                   .IsRequired();

            builder.HasOne(u => u.Funcionario);
        }
    }
}