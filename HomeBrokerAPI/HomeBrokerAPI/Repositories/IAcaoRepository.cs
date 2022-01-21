using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;

namespace HomeBrokerAPI.Repositories
{
    public interface IAcaoRepository : IDisposable
    {
        public Task<Acao> obterPorTicker(string ticker);
        public Task<double> precoMedio(string ticker);        
    }
}
