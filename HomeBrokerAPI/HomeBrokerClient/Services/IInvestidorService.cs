using HomeBrokerClient.Models.ViewModels;

namespace HomeBrokerClient.Services
{
    public interface IInvestidorService : IDisposable
    {
        public Task<InvestidorViewModel> obter();
    }
}
