using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Repositories;
using HomeBrokerAPI.ViewModels;

namespace HomeBrokerAPI.Services
{
    public class CorretoraService : ICorretoraService
    {
        private readonly ICorretoraRepository _corretoraRepository;

        public CorretoraService(ICorretoraRepository corretoraRepository)
        {
            this._corretoraRepository = corretoraRepository;
        }

        void IDisposable.Dispose()
        {
            _corretoraRepository?.Dispose();
        }

        public async Task<List<CorretoraViewModel>> listar()
        {
            var corretoras = await _corretoraRepository.listar();

            return corretoras.Select(
                    corretora => new CorretoraViewModel
                    {
                        Id = corretora.Id,
                        Nome = corretora.Nome
                    }
                ).ToList();
        }

        public async Task<CorretoraViewModel> obterPorId(int idCorretora)
        {
            var corretora = await _corretoraRepository.obterPorId(idCorretora);

            if (corretora == null)
                return null;

            return new CorretoraViewModel
            {
                Id = corretora.Id,
                Nome = corretora.Nome
            };
        }
    }
}
