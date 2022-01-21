using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace HomeBrokerAPI.Repositories
{
    public class AcaoRepository : IAcaoRepository
    {
        private readonly MySqlConnection _connection;

        public AcaoRepository(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration.GetConnectionString("DatabaseConnStr"));
        }

        public async Task<Acao> obterPorTicker(string ticker)
        {
            Acao acao = null;
            var comando = $"Select	A.Id, A.Ticker, A.IdEmpresa, E.Nome As Empresa From Acoes A Inner Join Empresas E on E.Id = A.IdEmpresa Where A.Ticker = '{ticker}';";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {
                Empresa empresa = new Empresa
                {
                    Id = Int32.Parse(mySqlDataReader["IdEmpresa"].ToString()),
                    Nome = (string)mySqlDataReader["Empresa"]
                };

                acao = new Acao
                {
                    Id = Int32.Parse(mySqlDataReader["Id"].ToString()),
                    Ticker = (string)mySqlDataReader["Ticker"],
                    Empresa = empresa
                };
            }

            await _connection.CloseAsync();

            return acao;
        }

        public Task<double> precoMedio(string ticker)
        {
            var media = 0.00;

            return Task.FromResult<double>(media);
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
