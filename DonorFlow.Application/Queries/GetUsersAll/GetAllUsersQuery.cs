using MediatR;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Queries.GetUsersAll
{
    public class GetAllUsersQuery : IRequest<BaseResult<List<GetAllUsersViewModel>>>
    {
        public GetAllUsersQuery() { }
    }
}
