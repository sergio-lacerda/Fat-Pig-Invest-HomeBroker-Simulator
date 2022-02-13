using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrokerAPI.ViewModels
{
    public class OrdemViewModel
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }        
        public char Tipo { get; set; }
        public string Ticker { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public string Status { get; set; }
    }
}
