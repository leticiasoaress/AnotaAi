using AnotaAi.Dominio.Entidades.Funcionarios;
using AnotaAi.Dominio.Interface.Respositorios.Funcionarios;
using AnotaAi.Repositorio.Contexto;

namespace AnotaAi.Repositorio.Repositorios.Funcionarios
{
    public class PessoaRepositorio : BaseRepositorio<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(AppDbContext context)
           : base(context)
        {
        }
    }
}