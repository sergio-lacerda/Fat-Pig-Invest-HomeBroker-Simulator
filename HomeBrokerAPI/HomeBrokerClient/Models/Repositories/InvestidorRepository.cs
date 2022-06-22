using HomeBrokerClient.Models.Entities;
using MySqlConnector;

namespace HomeBrokerClient.Models.Repositories
{
    public class InvestidorRepository : IInvestidorRepository
    {
        private readonly MySqlConnection _connection;
        private readonly int _idInvestidor;

        public InvestidorRepository(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration.GetConnectionString("DatabaseConnStr"));
            _idInvestidor = configuration.GetValue<int>("UsuarioLogado:IdInvestidor");
        }

        public async Task<Investidor> listar()
        {
            Investidor investidor = null;
                         
            var comando = $"Select * From Investidores Where Id = {_idInvestidor};";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {
                investidor = new Investidor
                {
                    Id = Int32.Parse(mySqlDataReader["Id"].ToString()),
                    Cpf = (string)mySqlDataReader["Cpf"],
                    Nome = (string)mySqlDataReader["Nome"],
                    Endereco = (string)mySqlDataReader["Endereco"],
                    Bairro = (string)mySqlDataReader["Bairro"],
                    Cep = (string)mySqlDataReader["Cep"],
                    Municipio = (string)mySqlDataReader["Municipio"],
                    Uf = (string)mySqlDataReader["Uf"]
                };
            }

            await _connection.CloseAsync();

            return investidor;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
