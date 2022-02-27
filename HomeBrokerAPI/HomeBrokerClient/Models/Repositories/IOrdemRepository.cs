using HomeBrokerClient.Models.Entities;

namespace HomeBrokerClient.Models.Repositories
{
    public interface IOrdemRepository : IDisposable
    {
        public Task<List<Ordem>> listar();
    }
}
