namespace HomeBrokerClient.Models.Entities
{
    public class Ordem
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }        
        public char Tipo { get; set; }
        public Acao Acao { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public string Status { get; set; }
    }
}
