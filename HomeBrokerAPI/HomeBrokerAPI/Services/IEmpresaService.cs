using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.ViewModels;

namespace HomeBrokerAPI.Services
{
    public interface IEmpresaService : IDisposable
    {
        Task<List<EmpresaViewModel>> listar();
        Task<EmpresaViewModel> obterPorId(int idEmpresa);
    }
}
