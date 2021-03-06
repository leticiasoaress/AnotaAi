using System;

namespace AnotaAi.Dominio.Entidades.Funcionarios
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }

        public void Atualizar(Pessoa pessoa)
        {
            Nome = pessoa.Nome;
            DataNascimento = pessoa.DataNascimento;
            Email = pessoa.Email;
            CEP = pessoa.CEP;
            Estado = pessoa.Estado;
            Cidade = pessoa.Cidade;
            Logradouro = pessoa.Logradouro;
            Numero = pessoa.Numero;
            Bairro = pessoa.Bairro;
        }
    }
}