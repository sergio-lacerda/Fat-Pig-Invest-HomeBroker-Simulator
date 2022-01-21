using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.ViewModels;

namespace HomeBrokerAPI.Services
{
    public interface IOfertaService : IDisposable
    {
        Task<List<OfertaViewModel>> listar(string ticker);
    }
}
