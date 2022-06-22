namespace HomeBrokerClient.Models.ViewModels
{
    public class NotaViewModel
    {
        public int NumeroNota { get; set; }
        public DateTime Pregao { get; set; }
        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public string CpfCliente { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public IEnumerable<OrdemViewModel> Ordens { get; set; }
        public double VendasAVista { get; set; }
        public double ComprasAVista { get; set; }
        public double TotalOperacoes{ get; set; }
        public double LiquidoOperacoes { get; set; }
        public double TaxaLiquidacao { get; set; }
        public double TotalCBLC { get; set; }
        public double Emolumentos { get; set; }
        public double TotalBolsa { get; set; }
        public double Corretagem { get; set; }
        public double ISS { get; set; }
        public double TotalCorretagemDespesas { get; set; }
        public double LiquidoNota { get; set; }
        public DateTime VenctoNota { get; set; }        
    }
}
