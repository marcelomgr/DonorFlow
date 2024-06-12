using MediatR;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.UserQueries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<BaseResult<GetUsersViewModel>>
    {
        public GetUserByEmailQuery(string email)
        {
            Email = email.Trim();
        }

        public string Email { get; private set; }
    }
}
