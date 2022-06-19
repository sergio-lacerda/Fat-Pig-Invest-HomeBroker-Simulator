using HomeBrokerClient.Models.Entities;
using HomeBrokerClient.Models.InputModels;
using System.Net.Http.Headers;

namespace HomeBrokerClient.Models.Repositories
{
    public class OrdemRepository : IOrdemRepository
    {
        private readonly HttpClient _httpClient;
        private string _uriBase;
        private string _uriOrdemList;
        private string _uriOrdemPost;

        public OrdemRepository(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _uriBase = configuration.GetValue<string>("ApiUris:Base");

            string _corretora = configuration.GetValue<string>("UsuarioLogado:IdCorretora");
            string _conta = configuration.GetValue<string>("UsuarioLogado:NumeroConta");

            _uriOrdemList = configuration.GetValue<string>("ApiUris:OrdemList") +
                            "/" + _corretora + "-"+ _conta;

            _uriOrdemPost = configuration.GetValue<string>("ApiUris:OrdemPost") +
                            "/" + _corretora + "-" + _conta;            
        }

        public async Task<List<Ordem>> listar()
        {
            List<Ordem> ordens = new List<Ordem>();
            
            _httpClient.BaseAddress = new Uri(_uriBase);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_uriOrdemList);
                if (response.IsSuccessStatusCode)
                {
                    ordens = await response.Content.ReadFromJsonAsync<List<Ordem>>();
                    return ordens;
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }

        public async Task<Ordem> adicionarOrdem(OrdemInputModel ordem)
        {
            Ordem insOrdem = new Ordem();

            _httpClient.BaseAddress = new Uri(_uriBase);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_uriOrdemPost);
                if (response.IsSuccessStatusCode)
                {
                    //ordens = await response.Content.ReadFromJsonAsync<List<Ordem>>();
                    return null;
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
