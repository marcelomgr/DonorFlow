using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DonorFlow.Application.Queries.DonationQueries.GetDonationsAll;
using DonorFlow.Application.Queries.DonationQueries.GetDonationById;

namespace DonorFlow.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/donations")]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetDonationsAllQuery();
            var result = await _mediator.Send(query);

            return result.Success ? Ok(result) : NotFound(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetDonationByIdQuery(id);
            var result = await _mediator.Send(query);

            return result.Success ? Ok(result) : NotFound(result.Message);
        }

    }
}
