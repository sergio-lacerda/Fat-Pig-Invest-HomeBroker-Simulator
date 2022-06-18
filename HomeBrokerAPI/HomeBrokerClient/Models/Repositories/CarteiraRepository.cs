using HomeBrokerClient.Models.Entities;
using System.Net.Http.Headers;

namespace HomeBrokerClient.Models.Repositories
{
    public class CarteiraRepository : ICarteiraRepository
    {
        private readonly HttpClient _httpClient;
        private string _uriBase;
        private string _uriCarteiraList;

        public CarteiraRepository(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _uriBase = configuration.GetValue<string>("ApiUris:Base");

            string _corretora = configuration.GetValue<string>("UsuarioLogado:IdCorretora");
            string _conta = configuration.GetValue<string>("UsuarioLogado:NumeroConta");

            _uriCarteiraList = configuration.GetValue<string>("ApiUris:CarteiraList") +
                            "/" + _corretora + "-" + _conta;
        }

        public async Task<List<CarteiraItem>> listar()
        {
            List<CarteiraItem> acoes = new List<CarteiraItem>();
            
            _httpClient.BaseAddress = new Uri(_uriBase);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_uriCarteiraList);
                if (response.IsSuccessStatusCode)
                {
                    acoes = await response.Content.ReadFromJsonAsync<List<CarteiraItem>>();
                    return acoes;
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }

        public void Dispose()
        {
            
        }
    }
}
