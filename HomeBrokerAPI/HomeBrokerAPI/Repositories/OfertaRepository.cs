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

            var comando = "Select 	 O.Id, O.DataHora, O.IdConta, Ct.IdCorretora, " +
                                    "C.Nome As Corretora, Ct.IdInvestidor, I.Cpf, " +
                                    "I.Nome As Investidor, Ct.Agencia, Ct.Conta, " +
                                    "O.Tipo, O.IdAcao, A.Ticker, A.IdEmpresa, " +
                                    "E.Nome As Empresa, O.Quantidade, O.PrecoUnitario " +
                          "From Ordens O " + 
                                "Inner Join Acoes A On A.Id = O.IdAcao " +
                                "Inner Join Empresas E On E.Id = A.IdEmpresa " +
                                "Inner Join Contas Ct On Ct.Id = O.IdConta " +
                                "Inner Join Corretoras C On C.Id = Ct.IdCorretora " + 
                                "Inner Join Investidores I On I.Id = Ct.IdInvestidor " +
                         $"Where A.Ticker = '{ticker}' And " +
                                "date_format(O.DataHora, '%Y%m%d') = date_format(Now(), '%Y%m%d') And " +
                                "O.IdStatus In (1, 2) " + 
                          "Order By O.Tipo, O.DataHora Desc; ";

            var comando_sp_simulador = $"Call Simular_Ofertas('{ticker}')";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommandSimulador = new MySqlCommand(comando_sp_simulador, _connection);
            await mySqlCommandSimulador.ExecuteNonQueryAsync();

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {
                string auxTipo = (string)mySqlDataReader["Tipo"];
                decimal auxPreco = (decimal)mySqlDataReader["PrecoUnitario"];

                Corretora corretora = new Corretora
                {
                    Id = Int32.Parse(mySqlDataReader["IdCorretora"].ToString()),
                    Nome = mySqlDataReader["Corretora"].ToString()
                };

                Investidor investidor = new Investidor
                {
                    Id = Int32.Parse(mySqlDataReader["IdInvestidor"].ToString()),
                    Nome = mySqlDataReader["Investidor"].ToString(),
                    Cpf = mySqlDataReader["Cpf"].ToString()
                };

                Conta conta = new Conta
                {
                    Id = Int32.Parse(mySqlDataReader["IdConta"].ToString()),
                    Corretora = corretora,
                    Investidor = investidor,
                    Agencia = Int32.Parse(mySqlDataReader["Agencia"].ToString()),
                    NumeroConta = Int32.Parse(mySqlDataReader["Conta"].ToString())
                };

                Empresa empresa = new Empresa
                {
                    Id = Int32.Parse(mySqlDataReader["IdEmpresa"].ToString()),
                    Nome = mySqlDataReader["Empresa"].ToString()
                };

                Acao acao = new Acao
                {
                    Id = Int32.Parse(mySqlDataReader["IdAcao"].ToString()),
                    Ticker = mySqlDataReader["Ticker"].ToString(),
                    Empresa = empresa
                };

                ofertas.Add(
                            new Oferta
                            {
                                Id = Int32.Parse(mySqlDataReader["Id"].ToString()),
                                DataHora = (DateTime)mySqlDataReader["DataHora"],
                                Conta = conta,
                                Tipo = auxTipo[0],
                                Acao = acao,                                
                                Quantidade = Int32.Parse(mySqlDataReader["Quantidade"].ToString()),
                                PrecoUnitario = (double)auxPreco                                
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
