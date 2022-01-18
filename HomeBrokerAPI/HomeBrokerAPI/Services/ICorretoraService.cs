using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.ViewModels;

namespace HomeBrokerAPI.Services
{
    public interface ICorretoraService : IDisposable
    {
        Task<List<CorretoraViewModel>> listar();
        Task<CorretoraViewModel> obterPorId(int idCorretora);
    }
}
