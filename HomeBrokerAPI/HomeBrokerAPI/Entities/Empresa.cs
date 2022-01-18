using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        public Empresa(int Id, string Nome, string Cnpj)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Cnpj = Cnpj;
        }
    }
}
