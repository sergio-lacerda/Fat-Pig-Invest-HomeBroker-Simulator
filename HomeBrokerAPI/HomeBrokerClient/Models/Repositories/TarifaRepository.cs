using HomeBrokerClient.Models.Entities;
using MySqlConnector;

namespace HomeBrokerClient.Models.Repositories
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly MySqlConnection _connection;

        public TarifaRepository(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration.GetConnectionString("DatabaseConnStr"));
        }

        public async Task<Tarifa> obter()
        {
            Tarifa tarifa = null;
            var comando = $"Select * From Tarifas Where Now() Between InicioVigencia And FinalVigencia;";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {
                tarifa = new Tarifa
                {
                    Id = Int32.Parse(mySqlDataReader["Id"].ToString()),
                    InicioVigencia = (DateTime)mySqlDataReader["InicioVigencia"],
                    FinalVigencia = (DateTime)mySqlDataReader["FinalVigencia"],
                    Corretagem = Double.Parse(mySqlDataReader["Corretagem"].ToString()),
                    TaxaLiquidacao = Double.Parse(mySqlDataReader["TaxaLiquidacao"].ToString()),
                    Emolumentos = Double.Parse(mySqlDataReader["Emolumentos"].ToString()),
                    Iss = Double.Parse(mySqlDataReader["Iss"].ToString())
                };
            }

            await _connection.CloseAsync();

            return tarifa;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
