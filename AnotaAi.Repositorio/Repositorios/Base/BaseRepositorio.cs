using AnotaAi.Dominio.Interface.Respositorios.Base;
using AnotaAi.Repositorio.Contexto;

using System.Collections.Generic;
using System.Linq;

namespace AnotaAi.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly AppDbContext Context;

        public BaseRepositorio(AppDbContext context)
        {
            Context = context;
        }

        public void Adicionar(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();
        }

        public void Excluir(TEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}