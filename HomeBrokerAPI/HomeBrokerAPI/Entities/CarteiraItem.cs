namespace HomeBrokerAPI.Entities
{
    public class CarteiraItem
    {
        public int Id { get; set; }
        public Conta Conta { get; set; }
        public Acao Acao { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public double Total { get; set; }
    }
}
