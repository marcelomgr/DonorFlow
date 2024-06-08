using DonorFlow.Core.Enums;

namespace DonorFlow.Core.Dtos
{
    public class DonorDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public LocationInfoDTO Location { get; set; }
    }
}
