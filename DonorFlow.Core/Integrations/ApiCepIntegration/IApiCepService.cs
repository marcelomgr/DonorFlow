using DonorFlow.Core.Integrations.ApiCepIntegration.Models;

namespace DonorFlow.Core.Integrations.ApiCepIntegration
{
    public interface IApiCepService
    {
        Task<CepViewModel?> GetByCep(string Cep);
    }
}
