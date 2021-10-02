using AnotaAi.Dominio.Entidades.Produtos;
using AnotaAi.Dominio.Interface.Respositorios.Produtos;
using AnotaAi.Repositorio.Contexto;

namespace AnotaAi.Repositorio.Repositorios.Produtos
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(AppDbContext context)
            : base(context)
        {
        }
    }
}