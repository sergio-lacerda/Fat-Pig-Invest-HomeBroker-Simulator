using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Entities
{
    public class Ordem
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int IdCorretora { get; set; }
        public string Corretora { get; set; }
        public int IdConta { get; set; }
        public string Conta { get; set; }
        public char Tipo { get; set; }
        public int IdAcao { get; set; }
        public string Ticker { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public int IdStatus { get; set; }
        public string Status { get; set; }
    }
}
