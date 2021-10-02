namespace AnotaAi.Dominio.Entidades.Funcionarios
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool IsMaster { get; set; }
        public bool Ativo { get; set; }

        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
    }
}