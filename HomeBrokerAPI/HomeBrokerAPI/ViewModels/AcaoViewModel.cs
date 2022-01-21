using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;

namespace HomeBrokerAPI.ViewModels
{
    public class AcaoViewModel
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public EmpresaViewModel Empresa { get; set; }        
    }
}
