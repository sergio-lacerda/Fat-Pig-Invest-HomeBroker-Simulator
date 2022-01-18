using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Repositories;
using HomeBrokerAPI.ViewModels;

namespace HomeBrokerAPI.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            this._empresaRepository = empresaRepository;               
        }
        public void Dispose()
        {
            _empresaRepository?.Dispose();
        }

        public async Task<List<EmpresaViewModel>> listar()
        {
            var empresas = await _empresaRepository.listar();

            return empresas.Select(
                    empresa => new EmpresaViewModel
                    {
                        Id = empresa.Id,
                        Nome = empresa.Nome,
                        Cnpj = empresa.Cnpj
                    }
                ).ToList();              
        }

        public async Task<EmpresaViewModel> obterPorId(int idEmpresa)
        {
            var empresa = await _empresaRepository.obterPorId(idEmpresa);

            if (empresa == null)
            {
                return null;
            }

            return new EmpresaViewModel
            {
                Id = empresa.Id,
                Nome = empresa.Nome,
                Cnpj = empresa.Cnpj
            };
        }
    }
}
