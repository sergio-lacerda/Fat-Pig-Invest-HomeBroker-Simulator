using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrokerAPI.InputModel
{
    public class OrdemInputModel
    {
        [Required]        
        public int IdCorretora { get; set; }
        [Required]
        public int Conta { get; set; }
        [Required]
        public char Tipo { get; set; }
        [Required]
        public String Ticker { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public double PrecoUnitario { get; set; }        
    }
}
