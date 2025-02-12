using DonorFlow.Core.Entities;

namespace DonorFlow.Application.Queries.Models
{
    public class GetDonationsViewModel
    {
        public GetDonationsViewModel(Donation donation)
        {
            Id = donation.Id;
            QuantityML = donation.QuantityML;
            DonorId = donation.DonorId;
            Donor = donation.Donor is not null ? new GetDonorsViewModel(donation.Donor) : null;
        }

        public Guid Id { get; set; }
        public int QuantityML { get; private set; }
        public Guid DonorId { get; private set; }
        public GetDonorsViewModel? Donor { get; private set; }
    }
}
