using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.ViewModels;

namespace HomeBrokerAPI.Services
{
    public interface IAcaoService : IDisposable
    {
        Task<AcaoViewModel> obterPorTicker(string ticker);
        Task<double> precoMedio(string ticker);        
    }
}
