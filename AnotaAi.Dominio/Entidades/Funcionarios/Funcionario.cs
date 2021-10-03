using System;

namespace AnotaAi.Dominio.Entidades.Funcionarios
{
    public class Funcionario
    {
        public int Id { get; set; }
        public DateTime DataContratacao { get; set; }

        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }

        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public void Atualizar(DateTime dataContratacao, int cargoId)
        {
            DataContratacao = dataContratacao;
            CargoId = cargoId;
        }
    }
}