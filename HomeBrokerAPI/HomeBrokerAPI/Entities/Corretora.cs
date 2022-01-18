using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Entities
{
    public class Corretora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        public Corretora(int id, string nome, string cnpj)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cnpj = cnpj;
        }
    }
}
