using HomeBrokerClient.Models.Repositories;
using HomeBrokerClient.Models.ViewModels;

namespace HomeBrokerClient.Services
{
    public class InvestidorService : IInvestidorService
    {
        private readonly IInvestidorRepository _investRepository;

        public InvestidorService(IInvestidorRepository investRepository)
        {
            this._investRepository = investRepository;
        }

        public async Task<InvestidorViewModel> obter()
        {
            var investEntity = await _investRepository.obter();

            if (investEntity == null)
                return null;

            InvestidorViewModel investidor = new InvestidorViewModel
            {
                Id = investEntity.Id,
                Cpf = investEntity.Cpf,
                Nome = investEntity.Nome,
                Endereco = investEntity.Endereco,
                Bairro = investEntity.Bairro,
                Municipio = investEntity.Municipio,
                Uf = investEntity.Uf,
                Cep = investEntity.Cep
            };

            return investidor;
        }

        public void Dispose()
        {
            _investRepository?.Dispose();
        }
    }
}
