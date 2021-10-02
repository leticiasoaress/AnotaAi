using AnotaAi.Dominio.Entidades.Comandas;
using AnotaAi.Dominio.Interface.Respositorios.Comandas;
using AnotaAi.Repositorio.Contexto;

namespace AnotaAi.Repositorio.Repositorios.Comandas
{
    public class ItemComandaRepositorio : BaseRepositorio<ItemComanda>, IItemComandaRepositorio
    {
        public ItemComandaRepositorio(AppDbContext context)
            : base(context)
        {
        }
    }
}