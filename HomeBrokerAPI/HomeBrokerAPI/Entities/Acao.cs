using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Entities
{
    public class Acao
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public Empresa Empresa { get; set; }        
    }
}
