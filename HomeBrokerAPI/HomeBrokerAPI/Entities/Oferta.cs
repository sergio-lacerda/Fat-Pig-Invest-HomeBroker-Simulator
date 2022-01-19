using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Entities
{
    public class Oferta
    {
        public string Ticker { get; set; }
        public Corretora Corretora { get; set; }
        public char Tipo { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }

        public Oferta(string ticker, Corretora corretora, char tipo, int quantidade, double precoUnitario)
        {
            this.Ticker = ticker;
            this.Corretora = corretora;
            this.Tipo = tipo;
            this.Quantidade = quantidade;
            this.PrecoUnitario = precoUnitario;
        }
    }
}
