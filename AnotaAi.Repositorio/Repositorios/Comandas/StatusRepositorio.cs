using AnotaAi.Dominio.Entidades.Comandas;
using AnotaAi.Dominio.Interface.Respositorios.Comandas;
using AnotaAi.Repositorio.Contexto;

namespace AnotaAi.Repositorio.Repositorios.Comandas
{
    public class StatusRepositorio : BaseRepositorio<Status>, IStatusRepositorio
    {
        public StatusRepositorio(AppDbContext context)
               : base(context)
        {
        }
    }
}