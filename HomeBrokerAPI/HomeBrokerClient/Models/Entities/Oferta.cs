namespace HomeBrokerClient.Models.Entities
{
    public class Oferta
    {
        public int Id { get; set; }
        public char Tipo { get; set; }
        public int IdAcao { get; set; }
        public string Ticker { get; set; }
        public int IdCorretora { get; set; }
        public string Corretora { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public DateTime DataHora { get; set; }
    }
}
