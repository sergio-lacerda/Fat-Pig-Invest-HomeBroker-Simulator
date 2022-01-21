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
            _connection = new MySqlConnection(configuration.GetConnectionString("Default"));
        }
        
        /*public static Dictionary<int, Empresa> empresas = new Dictionary<int, Empresa>()
        {
            { 1, new Empresa(1, "Empresa 001") },
            { 2, new Empresa(2, "Empresa 002") },
            { 3, new Empresa(3, "Empresa 003") },
            { 4, new Empresa(4, "Empresa 004") },
            { 5, new Empresa(5, "Empresa 005") },
            { 6, new Empresa(6, "Empresa 006") }
        };*/

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
            //return Task.FromResult(empresas.Values.ToList());
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
                    Id = (int)mySqlDataReader["Id"],
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
