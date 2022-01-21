using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace HomeBrokerAPI.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly MySqlConnection _connection;

        public EmpresaRepository(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration.GetConnectionString("DatabaseConnStr"));
        }

        public async Task<List<Empresa>> listar()
        {
            List<Empresa> empresas = new List<Empresa>();
            var comando = $"Select Id, Nome From Empresas;";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {
                empresas.Add(
                            new Empresa
                            {
                                Id = Int32.Parse( mySqlDataReader["Id"].ToString() ),
                                Nome = (string)mySqlDataReader["Nome"]
                            }
                         );
            }

            await _connection.CloseAsync();

            return empresas;
        }

        public async Task<Empresa> obterPorId(int idEmpresa)
        {
            Empresa empresa = null;
            var comando = $"Select Id, Nome From Empresas Where Id = {idEmpresa};";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {
                empresa = new Empresa
                {
                    Id = Int32.Parse( mySqlDataReader["Id"].ToString() ),
                    Nome = (string)mySqlDataReader["Nome"]
                };                
            }

            await _connection.CloseAsync();

            return empresa;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
