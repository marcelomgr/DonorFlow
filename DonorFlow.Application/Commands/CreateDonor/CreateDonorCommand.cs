using DonorFlow.Application.Models;
using DonorFlow.Core.Entities;
using DonorFlow.Core.Enums;
using MediatR;

namespace DonorFlow.Application.Commands.CreateDonor
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
