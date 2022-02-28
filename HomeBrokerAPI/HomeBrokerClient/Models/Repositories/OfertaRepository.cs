using HomeBrokerClient.Models.Entities;
using System.Net.Http.Headers;

namespace HomeBrokerClient.Models.Repositories
{
    public class OfertaRepository : IOfertaRepository
    {
        private readonly HttpClient _httpClient;
        private string _uriBase;
        private string _uriOfertaList;

        public OfertaRepository(IConfiguration configuration)
        {
            _httpClient = new HttpClient();

            _uriBase = configuration.GetValue<string>("ApiUris:Base");
            _uriOfertaList = configuration.GetValue<string>("ApiUris:OfertaList");
        }

        public async Task<List<Oferta>> listar(string ticker)
        {
            List<Oferta> ofertas = new List<Oferta>();

            _httpClient.BaseAddress = new Uri(_uriBase);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            try
            {                
                HttpResponseMessage response = await _httpClient.GetAsync(_uriOfertaList + "/" + ticker);
                if (response.IsSuccessStatusCode)
                {
                    ofertas = await response.Content.ReadFromJsonAsync<List<Oferta>>();
                    return ofertas;
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
