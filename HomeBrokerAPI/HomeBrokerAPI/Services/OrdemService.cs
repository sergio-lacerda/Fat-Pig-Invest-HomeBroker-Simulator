using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                            Corretora = ordem.Corretora,
                            Conta = ordem.Conta,
                            Tipo = ordem.Tipo,
                            Ticker = ordem.Ticker,
                            Quantidade = ordem.Quantidade,
                            PrecoUnitario = ordem.PrecoUnitario,
                            Status = ordem.Status
                        }
                    ).ToList();
        }

        public void Dispose()
        {
            _ordemRepository?.Dispose();
        }
    }
}
