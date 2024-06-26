﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DonorFlow.Core.Integrations.ApiCepIntegration;

namespace DonorFlow.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/cep")]
    public class CepController : ControllerBase
    {
        private readonly IApiCepService _apiCepService;
        public CepController(IApiCepService apiCepService)
        {
            _apiCepService = apiCepService;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> GetByCep(string cep)
        {
            var result = await _apiCepService.GetByCep(cep.Trim());
            
            return result is not null ? Ok(result) : NotFound("Cep não encontrado.");
        }
    }
}
