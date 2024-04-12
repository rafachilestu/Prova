namespace Questao5.Application.Commands.Requests
{
    public class MovimentoRequest
    {
        public int IdMovimento { get; set; }
        public int IdContaCorrente { get; set; }
        public string TipMovimento { get; set; }
        public double Valor { get; set; }
    }
}
