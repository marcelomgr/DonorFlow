using MediatR;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.DonorQueries.GetDonorsAll
{
    public class GetDonorsAllQuery : IRequest<BaseResult<List<GetDonorsViewModel>>>
    {
        public GetDonorsAllQuery() { }
    }
}
