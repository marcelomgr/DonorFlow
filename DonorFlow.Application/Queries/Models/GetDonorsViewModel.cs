using DonorFlow.Core.Enums;
using DonorFlow.Core.Entities;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Queries.Models
{
    public class GetDonorsViewModel
    {
        public GetDonorsViewModel(Donor donor)
        {
            Id = donor.Id;
            FullName = donor.FullName;
            Email = donor.Email;
            Weight = donor.Weight;
            BloodType = donor.BloodType;
            RhFactor = donor.RhFactor;
            Gender = donor.Gender;
            BirthDate = donor.BirthDate;
            Location = donor.Location is not null ? new LocationInfoModel(donor.Location) : null;
        }

        public Guid Id { get; set; }
        public string FullName { get; private set; }
        public string? Email { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public RhFactor RhFactor { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public LocationInfoModel? Location { get; set; }
    }
}
