using AnotaAi.Dominio.Entidades.Comandas;
using AnotaAi.Dominio.Entidades.Funcionarios;
using AnotaAi.Dominio.Entidades.Produtos;
using AnotaAi.Repositorio.Configuracao;
using Microsoft.EntityFrameworkCore;

namespace AnotaAi.Repositorio.Contexto
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ItemComanda> ItemComanda { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CargoConfiguracao());
            modelBuilder.ApplyConfiguration(new PessoaConfiguracao());
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguracao());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
            modelBuilder.ApplyConfiguration(new StatusConfiguracao());
            modelBuilder.ApplyConfiguration(new ComandaConfiguracao());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguracao());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguracao());
            modelBuilder.ApplyConfiguration(new ItemComandaConfiguracao());

            base.OnModelCreating(modelBuilder);
        }
    }
}