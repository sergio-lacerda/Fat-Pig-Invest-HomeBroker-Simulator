using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;

namespace HomeBrokerAPI.Repositories
{
    public interface IOrdemRepository : IDisposable
    {
        public Task<List<Ordem>> listar(string conta);
    }
}
