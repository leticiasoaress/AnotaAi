using AnotaAi.Dominio.Entidades.Funcionarios;
using AnotaAi.Dominio.Interface.Respositorios.Funcionarios;
using AnotaAi.Repositorio.Contexto;

namespace AnotaAi.Repositorio.Repositorios.Funcionarios
{
    public class FuncionarioRepositorio : BaseRepositorio<Funcionario>, IFuncionarioRepositorio
    {
        public FuncionarioRepositorio(AppDbContext context)
           : base(context)
        {
        }
    }
}