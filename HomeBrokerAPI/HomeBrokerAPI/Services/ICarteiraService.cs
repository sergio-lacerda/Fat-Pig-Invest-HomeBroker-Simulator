using HomeBrokerAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Services
{
    public interface ICarteiraService : IDisposable
    {
        Task<List<CarteiraViewModel>> listar(string conta);
    }
}
