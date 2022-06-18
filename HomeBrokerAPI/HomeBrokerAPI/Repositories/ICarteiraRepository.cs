using HomeBrokerAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Repositories
{
    public interface ICarteiraRepository : IDisposable
    {
        public Task<List<CarteiraItem>> listar(string conta);
    }
}
