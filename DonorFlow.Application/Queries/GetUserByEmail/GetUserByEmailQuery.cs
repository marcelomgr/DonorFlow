using MediatR;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<BaseResult<GetUserByEmailViewModel>>
    {
        public GetUserByEmailQuery(string email)
        {
            Email = email.Trim();
        }

        public string Email { get; private set; }
    }
}
