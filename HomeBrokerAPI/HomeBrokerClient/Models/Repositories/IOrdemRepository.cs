using HomeBrokerClient.Models.Entities;
using HomeBrokerClient.Models.InputModels;

namespace HomeBrokerClient.Models.Repositories
{
    public interface IOrdemRepository : IDisposable
    {
        public Task<List<Ordem>> listar();
        public Task<Ordem> adicionarOrdem(OrdemInputModel ordem);
    }
}
