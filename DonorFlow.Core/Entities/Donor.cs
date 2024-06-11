using DonorFlow.Core.Enums;
using DonorFlow.Core.ValueObjects;

namespace DonorFlow.Core.Entities
{
    public class Donor : Person
    {
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public RhFactor RhFactor { get; private set; }
        public LocationInfo? Location { get; private set; }

        public Donor(string fullName, string email, DateTime birthDate, Gender gender, double weight, BloodType bloodType, RhFactor rhFactor)
            : base(fullName, email, birthDate, gender)
        {
            if (weight < 50) throw new ArgumentException("Minimum weight is 50KG.");
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public void SetLocation(LocationInfo location)
        {
            Location = location;
        }

        public void Update(string fullName, string email, DateTime birthDate, Gender gender, double weight, BloodType bloodType, RhFactor rhFactor, LocationInfo location)
        {
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;

            Location = location;

            UpdatePerson(fullName, email, birthDate, gender);
        }
    }
}
