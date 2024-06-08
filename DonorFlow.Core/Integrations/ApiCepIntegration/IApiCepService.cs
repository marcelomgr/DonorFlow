using DonorFlow.Core.Integrations.ApiCepIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorFlow.Core.Integrations.ApiCepIntegration
{
    public interface IApiCepService
    {
        Task<CepViewModel?> GetByCep(string Cep);
    }
}
