using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;

namespace HomeBrokerAPI.Repositories
{
    public interface IOfertaRepository : IDisposable
    {
        public Task<List<Oferta>> listar(string ticker);
    }
}
