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

            return ordens.Select(
                    ordem => new OrdemViewModel
                    {
                        Id = ordem.Id,
                        Tipo = ordem.Tipo,
                        Ticker = ordem.Acao.Ticker,
                        Quantidade = ordem.Quantidade,
                        PrecoUnitario = ordem.PrecoUnitario,
                        Total = (double)ordem.Quantidade * ordem.PrecoUnitario,
                        PrecoMedio = ordem.PrecoUnitario,
                        DataHora = ordem.DataHora,
                        Status = ordem.Status
                    }
                ).ToList();
        }

        public void Dispose()
        {
            
        }
    }
}
