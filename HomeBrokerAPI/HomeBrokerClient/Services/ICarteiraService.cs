using HomeBrokerClient.Models.ViewModels;

namespace HomeBrokerClient.Services
{
    public interface ICarteiraService : IDisposable
    {
        public Task<List<CarteiraViewModel>> listar();
    }
}
