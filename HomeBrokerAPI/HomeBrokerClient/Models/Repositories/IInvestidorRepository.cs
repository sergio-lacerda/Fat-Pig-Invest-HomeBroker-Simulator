using HomeBrokerClient.Models.Entities;

namespace HomeBrokerClient.Models.Repositories
{
    public interface IInvestidorRepository : IDisposable
    {
        public Task<Investidor> listar();
    }
}
