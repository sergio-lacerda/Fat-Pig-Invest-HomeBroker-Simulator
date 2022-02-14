using System;
using System.Collections.Generic;
using System.Globalization;
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

        public async Task<List<Ordem>> listar(string conta)
        {
            List<Ordem> ordens = new List<Ordem>();

            var strConta = conta.Split("-");
            if (strConta.Length != 2)
                throw new IndexOutOfRangeException();

            int auxCorretora = Int32.Parse(strConta[0]);            
            int auxConta = Int32.Parse(strConta[1]);

            var comando = "Select	 O.Id, O.DataHora, " +
                                    "Ct.IdCorretora, C.Nome As Corretora, " +
                                    "I.Id AS IdInvestidor, I.Cpf, " +
                                    "I.Nome As NomeInvestidor, Ct.Id As IdConta, Ct.Agencia, Ct.Conta, " +
                                    "O.Tipo, O.IdAcao, A.Ticker, A.IdEmpresa, E.Nome As Empresa, " + 
                                    "O.Quantidade, O.PrecoUnitario, O.IdStatus, S.Nome As Status " +                                    
                            "From    Ordens O " +
                                        "Inner Join Acoes A On A.Id = O.IdAcao "+
                                        "Inner Join Empresas E On E.Id = A.IdEmpresa " +                                        
                                        "Inner Join Contas Ct On Ct.Id = O.IdConta " +
                                        "Inner Join Corretoras C On C.Id = Ct.IdCorretora " +
                                        "Inner Join Investidores I On I.Id = Ct.IdInvestidor " +
                                        "Inner Join StatusOrdem S On S.Id = O.IdStatus " +
                           $"Where Ct.IdCorretora = {auxCorretora} And " +
                                 $"Ct.Conta = {auxConta} " +                                  
                            "Order By O.DataHora Desc; ";

            await _connection.OpenAsync();

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
                    Cpf = mySqlDataReader["Cpf"].ToString(),
                    Nome = mySqlDataReader["NomeInvestidor"].ToString()
                };

                Conta contaAux = new Conta
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
                    Nome = mySqlDataReader["Empresa"].ToString(),
                };

                Acao acao = new Acao
                {
                    Id = Int32.Parse(mySqlDataReader["IdAcao"].ToString()),
                    Ticker = mySqlDataReader["Ticker"].ToString(),
                    Empresa = empresa
                };

                StatusOrdem status = new StatusOrdem
                {
                    Id = Int32.Parse(mySqlDataReader["IdStatus"].ToString()),
                    Nome = mySqlDataReader["Status"].ToString()
                };

                ordens.Add(
                    new Ordem
                    {
                        Id = Int32.Parse(mySqlDataReader["Id"].ToString()),
                        DataHora = (DateTime)mySqlDataReader["DataHora"],
                        Conta = contaAux,
                        Tipo = auxTipo[0],
                        Acao = acao,
                        Quantidade = Int32.Parse(mySqlDataReader["Quantidade"].ToString()),
                        PrecoUnitario = (double)auxPreco,
                        Status = status
                    }
                );
            }

            await _connection.CloseAsync();

            return ordens;
        }

        public async Task<Ordem> inserir(Ordem ordem)
        {
            Ordem auxOrdem = null;

            var comando = "Select	 O.Id, O.DataHora, " +
                                    "Ct.IdCorretora, C.Nome As Corretora, " +
                                    "I.Id AS IdInvestidor, I.Cpf, " +
                                    "I.Nome As NomeInvestidor, Ct.Id As IdConta, Ct.Agencia, Ct.Conta, " +
                                    "O.Tipo, O.IdAcao, A.Ticker, A.IdEmpresa, E.Nome As Empresa, " +
                                    "O.Quantidade, O.PrecoUnitario, O.IdStatus, S.Nome As Status " +
                            "From    Ordens O " +
                                        "Inner Join Acoes A On A.Id = O.IdAcao " +
                                        "Inner Join Empresas E On E.Id = A.IdEmpresa " +
                                        "Inner Join Contas Ct On Ct.Id = O.IdConta " +
                                        "Inner Join Corretoras C On C.Id = Ct.IdCorretora " +
                                        "Inner Join Investidores I On I.Id = Ct.IdInvestidor " +
                                        "Inner Join StatusOrdem S On S.Id = O.IdStatus " +
                           $"Where Ct.IdCorretora = {ordem.Conta.Corretora.Id} And " +
                                 $"Ct.Conta = {ordem.Conta.NumeroConta} " +
                            "Order By O.DataHora Desc Limit 1; ";

            var comando_sp_insert = "Call Inserir_Ordem(" +
                    $"{ordem.Conta.Corretora.Id}, " +
                    $"{ordem.Conta.NumeroConta}, " +                    
                    $"'{ordem.Tipo}', " +
                    $"'{ordem.Acao.Ticker}', " +
                    $"{ordem.Quantidade}, " +
                    $"{String.Format(CultureInfo.InvariantCulture, "{0:0.00}", ordem.PrecoUnitario)} " +
                ")";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommandInsert = new MySqlCommand(comando_sp_insert, _connection);
            await mySqlCommandInsert.ExecuteNonQueryAsync();

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
                    Cpf = mySqlDataReader["Cpf"].ToString(),
                    Nome = mySqlDataReader["NomeInvestidor"].ToString()
                };

                Conta contaAux = new Conta
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
                    Nome = mySqlDataReader["Empresa"].ToString(),
                };

                Acao acao = new Acao
                {
                    Id = Int32.Parse(mySqlDataReader["IdAcao"].ToString()),
                    Ticker = mySqlDataReader["Ticker"].ToString(),
                    Empresa = empresa
                };

                StatusOrdem status = new StatusOrdem
                {
                    Id = Int32.Parse(mySqlDataReader["IdStatus"].ToString()),
                    Nome = mySqlDataReader["Status"].ToString()
                };

                auxOrdem = new Ordem
                {
                    Id = Int32.Parse(mySqlDataReader["Id"].ToString()),
                    DataHora = (DateTime)mySqlDataReader["DataHora"],
                    Conta = contaAux,
                    Tipo = auxTipo[0],
                    Acao = acao,
                    Quantidade = Int32.Parse(mySqlDataReader["Quantidade"].ToString()),
                    PrecoUnitario = (double)auxPreco,
                    Status = status
                };                
            }

            await _connection.CloseAsync();

            return auxOrdem;
        }


        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
