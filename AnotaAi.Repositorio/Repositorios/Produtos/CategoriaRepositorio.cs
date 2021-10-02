using AnotaAi.Dominio.Entidades.Produtos;
using AnotaAi.Dominio.Interface.Respositorios.Produtos;
using AnotaAi.Repositorio.Contexto;

namespace AnotaAi.Repositorio.Repositorios.Produtos
{
    public class CategoriaRepositorio : BaseRepositorio<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(AppDbContext context)
            : base(context)
        {
        }
    }
}