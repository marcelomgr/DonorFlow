using MediatR;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.DonorQueries.GetDonorsAll
{
    public class GetAllDonorsQuery : IRequest<BaseResult<List<GetDonorsViewModel>>>
    {
        public GetAllDonorsQuery() { }
    }
}
