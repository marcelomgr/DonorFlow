using MediatR;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.UserCommands.ForgotPasswordUser
{
    public class ForgotPasswordUserCommand : IRequest<BaseResult>
    {
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string NewPassword { get; set; }
    }
}
