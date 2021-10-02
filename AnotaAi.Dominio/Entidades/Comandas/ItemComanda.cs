using AnotaAi.Dominio.Entidades.Produtos;

namespace AnotaAi.Dominio.Entidades.Comandas
{
    public class ItemComanda
    {
        public int Id { get; set; }      
        public int Quantidade { get; set; }

        public int ComandaId { get; set; }  
        public virtual Comanda Comanda { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}