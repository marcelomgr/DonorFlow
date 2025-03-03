using MediatR;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.DonationQueries.GetDonationsByDonorId
{
    public class GetDonationsByDonorIdQuery : IRequest<BaseResult<List<GetDonationsViewModel>>>
    {
        public GetDonationsByDonorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
