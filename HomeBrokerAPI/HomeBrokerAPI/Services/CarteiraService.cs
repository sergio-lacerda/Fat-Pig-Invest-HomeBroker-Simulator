using HomeBrokerAPI.Repositories;
using HomeBrokerAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Services
{
    public class CarteiraService : ICarteiraService
    {
        private readonly ICarteiraRepository _carteiraRepository;

        public CarteiraService(ICarteiraRepository carteiraRepository)
        {
            this._carteiraRepository = carteiraRepository;
        }

        public async Task<List<CarteiraViewModel>> listar(string conta)
        {
            var acoes = await _carteiraRepository.listar(conta);

            return acoes.Select(
                        item => new CarteiraViewModel
                        {
                            Ticker = item.Acao.Ticker,
                            Empresa = item.Acao.Empresa.Nome,
                            PrecoUnitario = item.PrecoUnitario,
                            Quantidade = item.Quantidade,
                            Total = item.Total
                        }
                    ).ToList();
        }

        public void Dispose()
        {
            _carteiraRepository.Dispose();
        }
    }
}
