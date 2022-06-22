using HomeBrokerClient.Models.Entities;

namespace HomeBrokerClient.Models.Repositories
{
    public interface ITarifaRepository : IDisposable
    {
        public Task<Tarifa> listar();
    }
}
