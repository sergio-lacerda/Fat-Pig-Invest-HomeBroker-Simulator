using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.ViewModels;

namespace HomeBrokerAPI.Services
{
    public interface IOrdemService : IDisposable
    {
        Task<List<OrdemViewModel>> listar(int IdConta);
    }
}
