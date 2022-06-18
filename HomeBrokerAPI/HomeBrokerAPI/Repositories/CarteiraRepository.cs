using HomeBrokerAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace HomeBrokerAPI.Repositories
{
    public class CarteiraRepository : ICarteiraRepository
    {
        private readonly MySqlConnection _connection;

        public CarteiraRepository(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration.GetConnectionString("DatabaseConnStr"));
        }

        public async Task<List<CarteiraItem>> listar(string conta)
        {
            List<CarteiraItem> acoes = new List<CarteiraItem>();

            var strConta = conta.Split("-");
            if (strConta.Length != 2)
                throw new IndexOutOfRangeException();

            int auxCorretora = Int32.Parse(strConta[0]);
            int auxConta = Int32.Parse(strConta[1]);

            var comando = "Select	C.Id, Ct.Id As IdConta, Ct.IdCorretora, " +
                                   "Cr.Nome As Corretora, Ct.Agencia, Ct.Conta, " +
                                   "Ct.IdInvestidor, C.IdAcao, A.Ticker, " +
                                   "A.IdEmpresa, E.Nome As Empresa, " +
                                   "A.PrecoBaseSimulacao, C.Quantidade, " +
                                   "PrecoSimulacao_Acao(A.Ticker, 'V') As ValorUnitario " +
                          "From Carteira C " +
                                "Inner Join Contas Ct On Ct.Id = C.IdConta " +
                                "Inner Join Corretoras Cr On Cr.Id = Ct.IdCorretora " +
                                "Inner Join Acoes A On A.Id = C.IdAcao " +
                                "Inner Join Empresas E On E.Id = A.IdEmpresa " +
                        $"Where Ct.IdCorretora = {auxCorretora} And " +
                              $"Ct.Conta = {auxConta}  " +
                        "Order By A.Ticker;";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {                
                decimal auxPreco = (decimal)mySqlDataReader["ValorUnitario"];
                int quant = Int32.Parse(mySqlDataReader["Quantidade"].ToString());

                Corretora corretora = new Corretora
                {
                    Id = Int32.Parse(mySqlDataReader["IdCorretora"].ToString()),
                    Nome = mySqlDataReader["Corretora"].ToString()
                };

                Conta contaAux = new Conta
                {
                    Id = Int32.Parse(mySqlDataReader["IdConta"].ToString()),
                    Corretora = corretora,
                    Investidor = null,
                    Agencia = Int32.Parse(mySqlDataReader["Agencia"].ToString()),
                    NumeroConta = Int32.Parse(mySqlDataReader["Conta"].ToString())
                };

                Empresa empresa = new Empresa
                {
                    Id = Int32.Parse(mySqlDataReader["IdEmpresa"].ToString()),
                    Nome = mySqlDataReader["Empresa"].ToString(),
                };

                Acao acao = new Acao
                {
                    Id = Int32.Parse(mySqlDataReader["IdAcao"].ToString()),
                    Ticker = mySqlDataReader["Ticker"].ToString(),
                    Empresa = empresa
                };

                acoes.Add(
                    new CarteiraItem
                    {
                        Id = Int32.Parse(mySqlDataReader["Id"].ToString()),                        
                        Conta = contaAux,                        
                        Acao = acao,
                        Quantidade = quant,
                        PrecoUnitario = (double)auxPreco,
                        Total = (quant * (double)auxPreco)
                    }
                );
            }

            await _connection.CloseAsync();

            return acoes;
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
