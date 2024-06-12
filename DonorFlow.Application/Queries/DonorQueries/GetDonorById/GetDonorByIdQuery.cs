using MediatR;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.DonorQueries.GetDonorById
{
    public class GetDonorByIdQuery : IRequest<BaseResult<GetDonorsViewModel>>
    {
        public GetDonorByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
