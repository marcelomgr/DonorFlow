using MediatR;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<BaseResult>
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
