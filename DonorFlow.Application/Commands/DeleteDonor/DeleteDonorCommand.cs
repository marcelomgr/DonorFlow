using MediatR;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.DeleteDonor
{
    public class DeleteDonorCommand : IRequest<BaseResult>
    {
        public DeleteDonorCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
