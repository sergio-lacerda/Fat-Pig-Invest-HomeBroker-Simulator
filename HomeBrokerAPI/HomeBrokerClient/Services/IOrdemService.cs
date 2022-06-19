using HomeBrokerClient.Models.InputModels;
using HomeBrokerClient.Models.ViewModels;

namespace HomeBrokerClient.Services
{
    public interface IOrdemService : IDisposable
    {
        Task<List<OrdemViewModel>> listar();
        Task<OrdemViewModel> adicionarOrdem(OrdemInputModel ordem);
    }
}
