namespace HomeBrokerClient.Models.ViewModels
{
    public class OrdemViewModel
    {
        public int Id { get; set; }
        public char Tipo { get; set; }
        public string Ticker { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public double Total { get; set; }
        public double PrecoMedio { get; set; }
        public DateTime DataHora { get; set; }
        public string Status { get; set; }
    }
}
