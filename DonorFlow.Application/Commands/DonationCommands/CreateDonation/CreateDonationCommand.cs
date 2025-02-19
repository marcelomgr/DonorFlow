using MediatR;
using DonorFlow.Core.Entities;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.DonationCommands.CreateDonation
{
    public class CreateDonationCommand : IRequest<BaseResult<Guid>>
    {
        public int QuantityML { get; set; }
        public Guid DonorId { get; set; }
        public Donation ToEntity(Donor donor) => new(QuantityML, donor);
    }
}
