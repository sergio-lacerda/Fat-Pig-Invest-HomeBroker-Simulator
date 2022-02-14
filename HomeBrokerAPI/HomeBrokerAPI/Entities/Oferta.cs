using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Entities
{
    public class Oferta
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public Conta Conta { get; set; }
        public char Tipo { get; set; }
        public Acao Acao { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }        
    }
}
