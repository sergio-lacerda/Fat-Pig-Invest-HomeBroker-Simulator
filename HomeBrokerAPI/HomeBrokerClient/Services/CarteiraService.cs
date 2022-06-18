using HomeBrokerClient.Models.Repositories;
using HomeBrokerClient.Models.ViewModels;

namespace HomeBrokerClient.Services
{
    public class CarteiraService : ICarteiraService
    {
        private readonly ICarteiraRepository _carteiraRepository;

        public CarteiraService(ICarteiraRepository carteiraRepository)
        {
            this._carteiraRepository = carteiraRepository;
        }

        public async Task<List<CarteiraViewModel>> listar()
        {
            var carteira = await _carteiraRepository.listar();

            if (carteira != null)
            {
                return carteira.Select(
                        acao => new CarteiraViewModel
                        {
                            Ticker = acao.Ticker,
                            Empresa = acao.Empresa,
                            Quantidade = acao.Quantidade,
                            PrecoUnitario = acao.PrecoUnitario,
                            Total = acao.Total
                        }
                    ).ToList();
            }

            List<CarteiraViewModel> listaVazia = new List<CarteiraViewModel>();
            return listaVazia;
        }

        public void Dispose()
        {
            
        }
    }
}
