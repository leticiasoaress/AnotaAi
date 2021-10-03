namespace AnotaAi.Dominio.Entidades.Produtos
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public void Atualizar(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}