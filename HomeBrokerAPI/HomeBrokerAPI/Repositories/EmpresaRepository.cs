using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;

namespace HomeBrokerAPI.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public static Dictionary<int, Empresa> empresas = new Dictionary<int, Empresa>()
        {
            { 1, new Empresa(1, "Empresa 001", "Cnpj 001") },
            { 2, new Empresa(2, "Empresa 002", "Cnpj 002") },
            { 3, new Empresa(3, "Empresa 003", "Cnpj 003") },
            { 4, new Empresa(4, "Empresa 004", "Cnpj 004") },
            { 5, new Empresa(5, "Empresa 005", "Cnpj 005") },
            { 6, new Empresa(6, "Empresa 006", "Cnpj 006") }
        };
        public Task<List<Empresa>> listar()
        {
            return Task.FromResult(empresas.Values.ToList());
        }

        public Task<Empresa> obterPorId(int idEmpresa)
        {
            if (!empresas.ContainsKey(idEmpresa))
                return Task.FromResult<Empresa>(null);
            return Task.FromResult<Empresa>(empresas[idEmpresa]);
        }

        public void Dispose()
        {

        }
    }
}
