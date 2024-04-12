namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public int IdMovimento { get; set; }
        public int IdContaCorrente { get; set;}
        public string DataMovimento { get; set;}
        public string TipMovimento { get; set;}
        public double Valor { get; set; }
    }
}
