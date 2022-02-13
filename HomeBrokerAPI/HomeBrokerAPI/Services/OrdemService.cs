using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Entities;
using HomeBrokerAPI.InputModel;
using HomeBrokerAPI.Repositories;
using HomeBrokerAPI.ViewModels;

namespace HomeBrokerAPI.Services
{
    public class OrdemService : IOrdemService
    {
        private readonly IOrdemRepository _ordemRepository;

        public OrdemService(IOrdemRepository ordemRepository)
        {
            this._ordemRepository = ordemRepository;
        }

        public async Task<List<OrdemViewModel>> listar(string conta)
        {
            var ordens = await _ordemRepository.listar(conta);

            return ordens.Select(
                        ordem => new OrdemViewModel
                        {
                            Id = ordem.Id,
                            DataHora = ordem.DataHora,
                            Tipo = ordem.Tipo,
                            Ticker = ordem.Acao.Ticker,                            
                            Quantidade = ordem.Quantidade,
                            PrecoUnitario = ordem.PrecoUnitario,
                            Status = ordem.Status.Nome
                        }
                    ).ToList();
        }


        public async Task<OrdemViewModel> inserir(OrdemInputModel ordem)
        {
            var auxOrdem = new Ordem
            {
                /*Id = -1,
                DataHora = DateTime.Now,
                IdCorretora = ordem.IdCorretora,
                Corretora = "",
                IdConta = ordem.IdConta,
                Conta = "",
                Tipo = ordem.Tipo,
                IdAcao = ordem.IdAcao,
                Ticker = "",
                Quantidade = ordem.Quantidade,
                PrecoUnitario = ordem.PrecoUnitario,
                IdStatus = -1,
                Status = ""*/
            };

            var ordemRetorno = await _ordemRepository.inserir(auxOrdem);

            if (ordemRetorno == null)
                return null;

            return new OrdemViewModel
            {
                /*Id = ordemRetorno.Id,
                DataHora = ordemRetorno.DataHora,
                Corretora = ordemRetorno.Corretora,
                Conta = ordemRetorno.Conta,
                Tipo = ordemRetorno.Tipo,
                Ticker = ordemRetorno.Ticker,
                Quantidade = ordemRetorno.Quantidade,
                PrecoUnitario = ordemRetorno.PrecoUnitario,
                Status = ordemRetorno.Status*/
            };
        }

        public void Dispose()
        {
            _ordemRepository?.Dispose();
        }
    }
}
