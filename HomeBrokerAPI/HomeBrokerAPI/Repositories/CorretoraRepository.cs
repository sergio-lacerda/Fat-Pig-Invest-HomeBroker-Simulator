using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace HomeBrokerAPI.Repositories
{
    public class CorretoraRepository : ICorretoraRepository
    {
        private readonly MySqlConnection _connection;

        public CorretoraRepository(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration.GetConnectionString("DatabaseConnStr"));
        }

        public async Task<List<Corretora>> listar()
        {
            List<Corretora> corretoras = new List<Corretora>();
            var comando = $"Select Id, Nome From Corretoras;";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {
                corretoras.Add(
                            new Corretora
                            {
                                Id = Int32.Parse(mySqlDataReader["Id"].ToString()),
                                Nome = (string)mySqlDataReader["Nome"]
                            }
                         );
            }

            await _connection.CloseAsync();

            return corretoras;
        }

        public async Task<Corretora> obterPorId(int idCorretora)
        {
            Corretora corretora = null;
            var comando = $"Select Id, Nome From Corretoras Where Id = {idCorretora};";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {
                corretora = new Corretora
                {
                    Id = Int32.Parse(mySqlDataReader["Id"].ToString()),
                    Nome = (string)mySqlDataReader["Nome"]
                };
            }

            await _connection.CloseAsync();

            return corretora;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
