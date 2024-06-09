using MediatR;
using DonorFlow.Core.Enums;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<BaseResult>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string CEP { get; set; }
        public string Role { get; set; }
    }
}
