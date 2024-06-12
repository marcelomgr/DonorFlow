using MediatR;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.UserCommands.AuthUser
{
    public class AuthUserCommand : IRequest<BaseResult<AuthViewModel>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
