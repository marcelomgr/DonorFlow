using MediatR;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.GetUsersAll
{
    public class GetAllUsersQuery : IRequest<BaseResult<List<GetUsersViewModel>>>
    {
        public GetAllUsersQuery() { }
    }
}
