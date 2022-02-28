
using HomeBrokerClient.Models.ViewModels;

namespace HomeBrokerClient.Services
{
    public interface IOfertaService : IDisposable
    {
        public Task<List<OfertaViewModel>> listar(string ticker);
    }
}
