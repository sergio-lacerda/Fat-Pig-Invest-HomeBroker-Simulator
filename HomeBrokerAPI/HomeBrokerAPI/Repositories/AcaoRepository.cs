using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;

namespace HomeBrokerAPI.Repositories
{
    public class AcaoRepository : IAcaoRepository
    {
        public static Dictionary<string, Acao> acoes = new Dictionary<string, Acao>()
        {
            {"ITSA4", new Acao("ITSA4", null, 9.60) },
            {"VIVT3", new Acao("VIVT3", null, 42.81) },
            {"PETR4", new Acao("PETR4", null, 16.54) },
            {"ITUB4", new Acao("ITUB4", null, 26.69) },
            {"ABVE3", new Acao("ABVE3", null, 23.98) }
        };

        public Task<bool> acaoValida(string ticker)
        {
            return Task.FromResult(acoes.ContainsKey(ticker));
        }

        public Task<Acao> obterPorTicker(string ticker)
        {
            if (!acoes.ContainsKey(ticker))
                return Task.FromResult<Acao>(null);

            return Task.FromResult<Acao>(acoes[ticker]);
        }

        public Task<double> precoMedio(string ticker)
        {
            if (!acoes.ContainsKey(ticker))
                return Task.FromResult<double>(0.00);

            var media = acoes[ticker].Ofertas.Average(valor => valor.PrecoUnitario);

            return Task.FromResult<double>(media);
        }

        public void Dispose()
        {
            
        }
    }
}
