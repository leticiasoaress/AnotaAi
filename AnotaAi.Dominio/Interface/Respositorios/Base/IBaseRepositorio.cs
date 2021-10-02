using System;
using System.Collections.Generic;

namespace AnotaAi.Dominio.Interface.Respositorios.Base
{
    public interface IBaseRepositorio<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity entity);
        void Excluir(TEntity entity);
    }
}