using Microsoft.AspNetCore.Mvc;
using DonorFlow.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace DonorFlow.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/enums")]
    public class EnumsController : ControllerBase
    {
        private readonly IEnumService _enumService;

        public EnumsController(IEnumService enumService)
        {
            _enumService = enumService;
        }

        [HttpGet("user")]
        public IActionResult GetUserEnums()
        {
            var enums = _enumService.GetUserEnums();
            return Ok(enums);
        }

        [HttpGet("donor")]
        public IActionResult GetDonorEnums()
        {
            var enums = _enumService.GetDonorEnums();
            return Ok(enums);
        }

        [HttpGet("person")]
        public IActionResult GetPersonEnums()
        {
            var enums = _enumService.GetPersonEnums();
            return Ok(enums);
        }
    }
}
