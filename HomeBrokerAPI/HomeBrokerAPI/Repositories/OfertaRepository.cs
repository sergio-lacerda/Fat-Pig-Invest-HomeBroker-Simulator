using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace HomeBrokerAPI.Repositories
{
    public class OfertaRepository : IOfertaRepository
    {
        private readonly MySqlConnection _connection;

        public OfertaRepository(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration.GetConnectionString("DatabaseConnStr"));
        }

        public async Task<List<Oferta>> listar(string ticker)
        {
            List<Oferta> ofertas = new List<Oferta>();
            var comando = $"Select O.Id, O.Tipo, O.IdAcao, " + 
                                  "A.Ticker, O.IdCorretora, C.Nome as Corretora, " +
                                  "O.Quantidade, O.PrecoUnitario, O.DataHora " +
                          "From Ofertas O " +
                                "Inner Join Acoes A On A.Id = O.IdAcao " +
                                "Inner Join Corretoras C on C.Id = O.IdCorretora " +
                          $"Where A.Ticker = '{ticker}' " +
                          "Order By O.DataHora Desc;";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {
                string auxTipo = (string)mySqlDataReader["Tipo"];
                decimal auxPreco = (decimal)mySqlDataReader["PrecoUnitario"];

                ofertas.Add(
                            new Oferta
                            {
                                Id = Int32.Parse(mySqlDataReader["Id"].ToString()),
                                Tipo = auxTipo[0],
                                IdAcao = Int32.Parse(mySqlDataReader["IdAcao"].ToString()),
                                Ticker = (string)mySqlDataReader["Ticker"],
                                IdCorretora = Int32.Parse(mySqlDataReader["IdCorretora"].ToString()),
                                Corretora = (string)mySqlDataReader["Corretora"],
                                Quantidade = Int32.Parse(mySqlDataReader["Quantidade"].ToString()),
                                PrecoUnitario = (double)auxPreco,
                                DataHora = (DateTime)mySqlDataReader["DataHora"]
                            }
                         );
            }

            await _connection.CloseAsync();

            return ofertas;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
