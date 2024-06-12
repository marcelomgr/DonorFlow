using MediatR;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.UserCommands.ResetPasswordUser
{
    public class ResetPasswordUserCommand : IRequest<BaseResult>
    {
        public Guid Id { get; set; }
        public string NewPassword { get; set; }
    }
}
