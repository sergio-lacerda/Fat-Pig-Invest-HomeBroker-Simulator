using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;

namespace HomeBrokerAPI.Repositories
{
    public interface ICorretoraRepository : IDisposable
    {
        public Task<List<Corretora>> listar();
        public Task<Corretora> obterPorId(int idCorretora);
    }
}
