using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace HomeBrokerAPI.Repositories
{
    public class OrdemRepository : IOrdemRepository
    {
        private readonly MySqlConnection _connection;

        public OrdemRepository(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration.GetConnectionString("DatabaseConnStr"));
        }

        public async Task<List<Ordem>> listar(int IdConta)
        {
            List<Ordem> ordens = new List<Ordem>();

            var comando =  "Select	 O.Id, O.DataHora, O.IdCorretora, O.IdConta, " +
                                    "O.Tipo, O.IdAcao, A.Ticker, O.Quantidade, " +
                                    "O.PrecoUnitario, O.IdStatus " +
                            "From    Ordens O " +
                                        "Inner Join Acoes A On A.Id = O.IdAcao "+
                           $"Where O.IdConta = {IdConta} "+
                            "Order By O.DataHora Desc; ";

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {
                string auxTipo = (string)mySqlDataReader["Tipo"];
                decimal auxPreco = (decimal)mySqlDataReader["PrecoUnitario"];

                ordens.Add(
                    new Ordem
                    {
                        Id = Int32.Parse(mySqlDataReader["Id"].ToString()),
                        DataHora = (DateTime)mySqlDataReader["DataHora"],
                        IdCorretora = Int32.Parse(mySqlDataReader["IdCorretora"].ToString()),
                        IdConta = Int32.Parse(mySqlDataReader["IdConta"].ToString()),
                        Tipo = auxTipo[0],
                        IdAcao =  Int32.Parse(mySqlDataReader["IdAcao"].ToString()),
                        Quantidade = Int32.Parse(mySqlDataReader["Quantidade"].ToString()),
                        PrecoUnitario = (double) auxPreco,
                        IdStatus = Int32.Parse(mySqlDataReader["IdStatus"].ToString())
                    }
                );
            }

            await _connection.CloseAsync();

            return ordens;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
