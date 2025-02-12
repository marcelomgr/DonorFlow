using MediatR;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.DonationQueries.GetDonationsAll
{
    public class GetDonationsAllQuery : IRequest<BaseResult<List<GetDonationsViewModel>>>
    {
        public GetDonationsAllQuery() { }
    }
}
