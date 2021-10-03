using AnotaAi.Dominio.Entidades.Comandas;
using AnotaAi.Dominio.Interface.Respositorios.Comandas;

using AnotaAi.Repositorio.Contexto;

using System.Collections.Generic;
using System.Linq;

namespace AnotaAi.Repositorio.Repositorios.Comandas
{
    public class ItemComandaRepositorio : BaseRepositorio<ItemComanda>, IItemComandaRepositorio
    {
        public ItemComandaRepositorio(AppDbContext context)
            : base(context)
        {
        }

        public IEnumerable<ItemComanda> ObterPorComandaId(int comandaId)
        {
            return ObterTodos().Where(i => i.ComandaId == comandaId);
        }
    }
}