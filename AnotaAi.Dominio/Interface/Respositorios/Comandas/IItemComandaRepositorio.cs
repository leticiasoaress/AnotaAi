using AnotaAi.Dominio.Entidades.Comandas;
using AnotaAi.Dominio.Interface.Respositorios.Base;

using System.Collections.Generic;

namespace AnotaAi.Dominio.Interface.Respositorios.Comandas
{
    public interface IItemComandaRepositorio : IBaseRepositorio<ItemComanda>
    {
        IEnumerable<ItemComanda> ObterPorComandaId(int comandaId);
    }
}