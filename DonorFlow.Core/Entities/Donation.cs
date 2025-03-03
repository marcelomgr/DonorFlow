using DonorFlow.Core.Enums;

namespace DonorFlow.Core.Entities
{
    public class Donation : BaseEntity
    {
        private Donation() { } // Construtor privado para o EF

        public Donation(int quantityMl, Donor donor)
        {
            QuantityML = quantityMl;
            DonorId = donor?.Id ?? throw new ArgumentNullException(nameof(donor));
            Donor = donor;
        }

        public int QuantityML { get; private set; }
        public Guid DonorId { get; private set; }
        public Donor Donor { get; private set; }

        public bool IsLastDonationSufficientOld(Gender gender)
        {
            if (gender == Gender.Male)
                return CreatedAt <= DateTime.Today.AddDays(-60);

            return CreatedAt <= DateTime.Today.AddDays(-90);
        }
    }
}
