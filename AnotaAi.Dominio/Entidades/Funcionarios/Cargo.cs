namespace AnotaAi.Dominio.Entidades.Funcionarios
{
    public class Cargo
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