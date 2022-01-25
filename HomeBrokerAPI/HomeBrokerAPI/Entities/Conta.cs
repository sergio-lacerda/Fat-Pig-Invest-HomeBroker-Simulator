using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Entities
{
    public class Conta
    {
        public int Id { get; set; }
        public int Agencia { get; set; }
        public int NumeroConta { get; set; }
        public Cliente Cliente { get; set; }
        public double Saldo { get; set; }        
    }
}
