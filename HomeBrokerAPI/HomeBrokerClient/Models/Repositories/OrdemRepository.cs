﻿using HomeBrokerClient.Models.Entities;
using HomeBrokerClient.Models.InputModels;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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

            _uriOrdemPost = configuration.GetValue<string>("ApiUris:OrdemPost");            
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
            _httpClient.BaseAddress = new Uri(_uriBase);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            try
            {
                string jsonOrdem = JsonSerializer.Serialize(ordem);
                var auxOrdem = new StringContent(jsonOrdem, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(_uriOrdemPost, auxOrdem);

                if (response.IsSuccessStatusCode)
                {
                    Ordem insOrdem = new Ordem();                    
                    insOrdem = await response.Content.ReadFromJsonAsync<Ordem>();
                    return insOrdem;
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
