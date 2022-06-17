using HomeBrokerClient.Models.Entities;

namespace HomeBrokerClient.Models.Repositories
{
    public interface ICarteiraRepository : IDisposable
    {
        public Task<List<CarteiraItem>> listar();
    }
}
