using HomeBrokerClient.Models.Entities;

namespace HomeBrokerClient.Models.Repositories
{
    public class OrdemRepository : IOrdemRepository
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Ordem>> listar()
        {
            List<Ordem> ordens = new List<Ordem>();


            ordens.Add(
                    new Ordem
                    {
                        Id = 1,
                        DataHora = DateTime.Now,
                        Acao = new Acao
                        {
                            Id = 1,
                            Ticker = "XPTO",
                            Empresa = "XPTO Company"
                        },
                        Tipo = 'C',
                        PrecoUnitario = 12.3657,
                        Quantidade = 200,
                        Status = "Executada"                        
                    }
                );

            return ordens;
        }

        public void Dispose()
        {
            
        }
    }
}
