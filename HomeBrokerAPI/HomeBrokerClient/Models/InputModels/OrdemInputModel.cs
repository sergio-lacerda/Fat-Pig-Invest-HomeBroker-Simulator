namespace HomeBrokerClient.Models.InputModels
{
    public class OrdemInputModel
    {        
        public int IdCorretora { get; set; }     
        public int Conta { get; set; }        
        public char Tipo { get; set; }        
        public String Ticker { get; set; }        
        public int Quantidade { get; set; }        
        public double PrecoUnitario { get; set; }
    }
}
