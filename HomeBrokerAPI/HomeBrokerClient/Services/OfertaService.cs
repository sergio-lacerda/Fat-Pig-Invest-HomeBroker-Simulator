using HomeBrokerClient.Models.Repositories;
using HomeBrokerClient.Models.ViewModels;

namespace HomeBrokerClient.Services
{
    public class OfertaService : IOfertaService
    {
        private readonly IOfertaRepository _ofertaRepository;

        public OfertaService(IOfertaRepository ofertaRepository)
        {
            _ofertaRepository = ofertaRepository;
        }

        public async Task<List<OfertaViewModel>> listar(string ticker)
        {
            var ofertas = await _ofertaRepository.listar(ticker);

            if (ofertas != null)
            {
                return ofertas.Select(
                    oferta => new OfertaViewModel
                    {
                        Corretora = oferta.Corretora,
                        Quantidade = oferta.Quantidade,
                        Valor = oferta.PrecoUnitario,
                        Tipo = oferta.Tipo
                    }
                ).ToList();
            }

            List<OfertaViewModel> listaVazia = new List<OfertaViewModel>();

            return listaVazia;            
        }

        public void Dispose()
        {
            
        }
    }
}
