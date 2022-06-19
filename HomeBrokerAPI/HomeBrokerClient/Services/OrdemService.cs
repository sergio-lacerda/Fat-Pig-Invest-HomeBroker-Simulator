using HomeBrokerClient.Models.InputModels;
using HomeBrokerClient.Models.Repositories;
using HomeBrokerClient.Models.ViewModels;

namespace HomeBrokerClient.Services
{
    public class OrdemService : IOrdemService
    {
        private readonly IOrdemRepository _ordemRepository;

        public OrdemService(IOrdemRepository ordemRepository)
        {
            this._ordemRepository = ordemRepository;
        }

        public async Task<List<OrdemViewModel>> listar()
        {
            var ordens = await _ordemRepository.listar();

            if (ordens != null)
            {
                return ordens.Select(
                    ordem => new OrdemViewModel
                    {
                        Id = ordem.Id,
                        Tipo = ordem.Tipo,
                        Ticker = ordem.Ticker,
                        Quantidade = ordem.Quantidade,
                        PrecoUnitario = ordem.PrecoUnitario,
                        Total = (double)ordem.Quantidade * ordem.PrecoUnitario,
                        PrecoMedio = ordem.PrecoUnitario,
                        DataHora = ordem.DataHora,
                        Status = ordem.Status
                    }
                ).ToList();
            }

            List<OrdemViewModel> listaVazia = new List<OrdemViewModel>();

            return listaVazia;            
        }

        public async Task<OrdemViewModel> adicionarOrdem(OrdemInputModel ordem)
        {
            var insOrdem = await _ordemRepository.adicionarOrdem(ordem);

            if (insOrdem != null)
                return new OrdemViewModel
                    {
                        Id = insOrdem.Id,
                        Tipo = insOrdem.Tipo,
                        Ticker = insOrdem.Ticker,
                        Quantidade = insOrdem.Quantidade,
                        PrecoUnitario = insOrdem.PrecoUnitario,
                        Total = (double)insOrdem.Quantidade * insOrdem.PrecoUnitario,
                        PrecoMedio = insOrdem.PrecoUnitario,
                        DataHora = insOrdem.DataHora,
                        Status = insOrdem.Status
                    };

            return null;
        }

        public void Dispose()
        {
            
        }
    }
}
