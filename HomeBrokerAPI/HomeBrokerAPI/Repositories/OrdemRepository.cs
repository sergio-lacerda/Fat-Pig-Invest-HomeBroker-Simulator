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
        private readonly int _agencia;
        private readonly int _conta;

        public OrdemRepository(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration.GetConnectionString("DatabaseConnStr"));
            _agencia = configuration.GetValue<int>("Agencia");
            _conta = configuration.GetValue<int>("conta");
        }

        public async Task<List<Ordem>> listar(string conta)
        {
            List<Ordem> ordens = new List<Ordem>();

            var strConta = conta.Split("-");
            int auxCorretora = Int32.Parse(strConta[0]);            
            int auxConta = Int32.Parse(strConta[1]);

            var comando =  "Select	 O.Id, O.DataHora, O.IdCorretora, C.Nome As Corretora, " +
                                    "O.Tipo, O.IdAcao, A.Ticker, O.Quantidade, " +
                                    "O.PrecoUnitario, O.IdStatus, S.Nome As Status, " +
                                    "O.IdConta, Concat(Ct.Agencia,'-',Ct.Conta) As Conta " +
                            "From    Ordens O " +
                                        "Inner Join Acoes A On A.Id = O.IdAcao "+
                                        "Inner Join Corretoras C On C.Id = O.IdCorretora " +
                                        "Inner Join Contas Ct On Ct.Id = O.IdConta " +
                                        "Inner Join StatusOrdem S On S.Id = O.IdStatus " +
                           $"Where O.IdCorretora = {auxCorretora} And " +
                                 $"O.IdConta = {auxConta} " +                                  
                            "Order By O.DataHora Desc; ";

            await _connection.OpenAsync();

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
                        Corretora = mySqlDataReader["Corretora"].ToString(),
                        IdConta = Int32.Parse(mySqlDataReader["IdConta"].ToString()),
                        Conta = mySqlDataReader["Conta"].ToString(),
                        Tipo = auxTipo[0],
                        IdAcao =  Int32.Parse(mySqlDataReader["IdAcao"].ToString()),
                        Ticker = mySqlDataReader["Ticker"].ToString(),
                        Quantidade = Int32.Parse(mySqlDataReader["Quantidade"].ToString()),
                        PrecoUnitario = (double) auxPreco,
                        IdStatus = Int32.Parse(mySqlDataReader["IdStatus"].ToString()),
                        Status = mySqlDataReader["Status"].ToString(),
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
