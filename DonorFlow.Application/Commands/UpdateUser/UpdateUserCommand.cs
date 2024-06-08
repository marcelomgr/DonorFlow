using MediatR;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<BaseResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Role { get; set; }
    }
}
