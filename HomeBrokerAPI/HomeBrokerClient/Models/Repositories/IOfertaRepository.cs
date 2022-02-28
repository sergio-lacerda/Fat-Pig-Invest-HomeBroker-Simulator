namespace HomeBrokerClient.Models.Repositories
{
    public interface IOfertaRepository : IDisposable
    {
        public Task<List<Entities.Oferta>> listar(string ticker);
    }
}
