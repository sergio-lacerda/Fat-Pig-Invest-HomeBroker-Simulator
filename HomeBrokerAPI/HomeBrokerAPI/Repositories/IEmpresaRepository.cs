using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;

namespace HomeBrokerAPI.Repositories
{
    public interface IEmpresaRepository : IDisposable
    {
        public Task<List<Empresa>> listar();
        public Task<Empresa> obterPorId(int idEmpresa);
    }
}
