using AnotaAi.Dominio.Entidades.Funcionarios;

namespace AnotaAi.Dominio.Entidades.Comandas
{
    public class Comanda
    {
        public int Id { get; set; }
        public int NumeroMesa { get; set; }
        public string NomeCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorPago { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public void Atualizar(Comanda comanda)
        {
            NumeroMesa = comanda.NumeroMesa;
            NomeCliente = comanda.NomeCliente;
            ValorTotal = comanda.ValorTotal;
            ValorDesconto = comanda.ValorDesconto;
            ValorPago = comanda.ValorPago;
            StatusId = comanda.StatusId;
            UsuarioId = comanda.UsuarioId;
        }
    }
}