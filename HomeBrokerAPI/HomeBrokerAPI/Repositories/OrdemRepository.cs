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
           
            /*var comando = "Insert Into Ordens (IdCorretora, IdConta, Tipo, IdAcao, Quantidade, PrecoUnitario) " +
                         $"Values ({ordem.IdCorretora}, {ordem.IdConta}, '{ordem.Tipo}', {ordem.IdAcao}, {ordem.Quantidade}, " + 
                                 $"{String.Format(CultureInfo.InvariantCulture, "{0:0.00}", ordem.PrecoUnitario)});";

            await _connection.OpenAsync();

            MySqlCommand mySqlCommand = new MySqlCommand(comando, _connection);
            await mySqlCommand.ExecuteNonQueryAsync();

            comando =       "Select	 O.Id, O.DataHora, O.IdCorretora, C.Nome As Corretora, " +
                                    "O.Tipo, O.IdAcao, A.Ticker, O.Quantidade, " +
                                    "O.PrecoUnitario, O.IdStatus, S.Nome As Status, " +
                                    "O.IdConta, Concat(Ct.Agencia,'-',Ct.Conta) As Conta " +
                            "From    Ordens O " +
                                        "Inner Join Acoes A On A.Id = O.IdAcao " +
                                        "Inner Join Corretoras C On C.Id = O.IdCorretora " +
                                        "Inner Join Contas Ct On Ct.Id = O.IdConta " +
                                        "Inner Join StatusOrdem S On S.Id = O.IdStatus " +
                           $"Where O.IdCorretora = {ordem.IdCorretora} And " +
                                 $"O.IdConta = {ordem.IdConta} " +
                            "Order By O.DataHora Desc Limit 1; ";

            mySqlCommand = new MySqlCommand(comando, _connection);
            MySqlDataReader mySqlDataReader = await mySqlCommand.ExecuteReaderAsync();

            while (mySqlDataReader.Read())
            {
                string auxTipo = (string)mySqlDataReader["Tipo"];
                decimal auxPreco = (decimal)mySqlDataReader["PrecoUnitario"];

                auxOrdem = new Ordem
                {
                    Id = Int32.Parse(mySqlDataReader["Id"].ToString()),
                    DataHora = (DateTime)mySqlDataReader["DataHora"],
                    IdCorretora = Int32.Parse(mySqlDataReader["IdCorretora"].ToString()),
                    Corretora = mySqlDataReader["Corretora"].ToString(),
                    IdConta = Int32.Parse(mySqlDataReader["IdConta"].ToString()),
                    Conta = mySqlDataReader["Conta"].ToString(),
                    Tipo = auxTipo[0],
                    IdAcao = Int32.Parse(mySqlDataReader["IdAcao"].ToString()),
                    Ticker = mySqlDataReader["Ticker"].ToString(),
                    Quantidade = Int32.Parse(mySqlDataReader["Quantidade"].ToString()),
                    PrecoUnitario = (double)auxPreco,
                    IdStatus = Int32.Parse(mySqlDataReader["IdStatus"].ToString()),
                    Status = mySqlDataReader["Status"].ToString()
                };
            }            

            await _connection.CloseAsync();*/
            return auxOrdem;
        }


        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
