namespace HomeBrokerClient.Models.Entities
{
    public class Tarifa
    {
        public int Id { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FinalVigencia { get; set; }
        public double Corretagem { get; set; }
        public double TaxaLiquidacao { get; set; }
        public double Emolumentos { get; set; }
        public double Iss { get; set; }
    }
}
