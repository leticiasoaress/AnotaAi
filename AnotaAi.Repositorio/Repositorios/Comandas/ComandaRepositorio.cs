using AnotaAi.Dominio.Entidades.Comandas;
using AnotaAi.Dominio.Interface.Respositorios.Comandas;
using AnotaAi.Repositorio.Contexto;

namespace AnotaAi.Repositorio.Repositorios.Comandas
{
    public class ComandaRepositorio : BaseRepositorio<Comanda>, IComandaRepositorio
    {
        public ComandaRepositorio(AppDbContext context)
            : base(context)
        {
        }
    }
}