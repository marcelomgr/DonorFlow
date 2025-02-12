using MediatR;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.DonationQueries.GetDonationById
{
    public class GetDonationByIdQuery : IRequest<BaseResult<GetDonationsViewModel>>
    {
        public GetDonationByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
