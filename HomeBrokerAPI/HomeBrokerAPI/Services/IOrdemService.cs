using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.InputModel;
using HomeBrokerAPI.ViewModels;

namespace HomeBrokerAPI.Services
{
    public interface IOrdemService : IDisposable
    {
        Task<List<OrdemViewModel>> listar(string conta);
        Task<OrdemViewModel> inserir(OrdemInputModel ordem);
    }
}
