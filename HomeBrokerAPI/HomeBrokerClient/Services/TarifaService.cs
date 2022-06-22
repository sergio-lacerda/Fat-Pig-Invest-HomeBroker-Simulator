using HomeBrokerClient.Models.Repositories;
using HomeBrokerClient.Models.ViewModels;

namespace HomeBrokerClient.Services
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository _tarifaRepository;

        public TarifaService(ITarifaRepository tarifaRepository)
        {
            this._tarifaRepository = tarifaRepository;
        }

        public async Task<TarifaViewModel> obter()
        {
            var tarifaEntity = await _tarifaRepository.obter();

            if (tarifaEntity == null)
                return null;

            TarifaViewModel tarifa = new TarifaViewModel
            {
                Corretagem = tarifaEntity.Corretagem,
                Emolumentos = tarifaEntity.Emolumentos,
                Iss = tarifaEntity.Iss,
                TaxaLiquidacao = tarifaEntity.TaxaLiquidacao
            };

            return tarifa;
        }

        public void Dispose()
        {
            _tarifaRepository?.Dispose();
        }
    }
}
