using MediatR;
using DonorFlow.Core.Enums;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.DonorCommands.UpdateDonor
{
    public class UpdateDonorCommand : IRequest<BaseResult>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public string CEP { get; set; }
    }
}
