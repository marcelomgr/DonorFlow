using MediatR;
using DonorFlow.Core.Enums;
using DonorFlow.Core.Entities;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<BaseResult<Guid>>
    {
        public string FullName { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
        public string CEP { get; set; }

        public User ToEntity() => new(FullName, CPF, Password, Email, BirthDate, Gender, Role);
    }
}
