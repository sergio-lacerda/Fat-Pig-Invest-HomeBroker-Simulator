using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;

namespace HomeBrokerAPI.Repositories
{
    public class CorretoraRepository : ICorretoraRepository
    {
        public static Dictionary<int, Corretora> corretoras = new Dictionary<int, Corretora>()
        {
            { 1, new Corretora(1, "Corretora 001", "Cnpj 001") },
            { 2, new Corretora(2, "Corretora 002", "Cnpj 002") },
            { 3, new Corretora(3, "Corretora 003", "Cnpj 003") },
            { 4, new Corretora(4, "Corretora 004", "Cnpj 004") },
            { 5, new Corretora(5, "Corretora 005", "Cnpj 005") },
            { 6, new Corretora(6, "Corretora 006", "Cnpj 006") }
        };

        public void Dispose()
        {
            
        }

        public Task<List<Corretora>> listar()
        {
            return Task.FromResult(corretoras.Values.ToList());
        }

        public Task<Corretora> obterPorId(int idCorretora)
        {
            if (!corretoras.ContainsKey(idCorretora))
                return Task.FromResult<Corretora>(null);
            return Task.FromResult<Corretora>(corretoras[idCorretora]);
        }
    }
}
