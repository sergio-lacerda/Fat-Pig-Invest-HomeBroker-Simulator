using HomeBrokerClient.Models.ViewModels;

namespace HomeBrokerClient.Services
{
    public interface ITarifaService : IDisposable
    {
        public Task<TarifaViewModel> obter();
    }
}
