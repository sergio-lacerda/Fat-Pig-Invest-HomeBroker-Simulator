using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Repositories;
using HomeBrokerAPI.ViewModels;

namespace HomeBrokerAPI.Services
{
    public class AcaoService : IAcaoService
    {
        private readonly IAcaoRepository _acaoRepository;

        public AcaoService(IAcaoRepository acaoRepository)
        {
            this._acaoRepository = acaoRepository;
        }

        public async Task<bool> acaoValida(string ticker)
        {
            return await _acaoRepository.acaoValida(ticker);
        }
        
        public async Task<AcaoViewModel> obterPorTicker(string ticker)
        {
            var acao = await _acaoRepository.obterPorTicker(ticker);

            if (acao == null)
                return null;

            return new AcaoViewModel
            {
                Ticker = acao.Ticker,
                Empresa = acao.Empresa,
                Ofertas = acao.Ofertas
            };
        }

        public async Task<double> precoMedio(string ticker)
        {
            return await _acaoRepository.precoMedio(ticker);
        }

        public void Dispose()
        {
            _acaoRepository?.Dispose();
        }
    }
}
