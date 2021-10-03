namespace AnotaAi.Dominio.Entidades.Produtos
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public void Atualizar(Produto produto)
        {
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            Valor = produto.Valor;
            CategoriaId = produto.CategoriaId;
        }
    }
}