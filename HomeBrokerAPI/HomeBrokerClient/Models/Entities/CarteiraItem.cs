namespace HomeBrokerClient.Models.Entities
{
    public class CarteiraItem
    {
        public string Ticker { get; set; }
        public string Empresa { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public double Total { get; set; }
    }
}
