using MediatR;
using DonorFlow.Core.Enums;
using DonorFlow.Core.Entities;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.DonorCommands.CreateDonor
{
    public class CreateDonorCommand : IRequest<BaseResult<Guid>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public string CEP { get; set; }

        public Donor ToEntity() => new(FullName, Email, BirthDate, Gender, Weight, BloodType, RhFactor);
    }
}
