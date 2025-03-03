using MediatR;
using FluentValidation;
using DonorFlow.Application.Models;
using DonorFlow.Core.Repositories;
using DonorFlow.Core.Entities;

namespace DonorFlow.Application.Commands.DonationCommands.CreateDonation
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, BaseResult<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateDonationCommand> _validator;

        public CreateDonationCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateDonationCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<BaseResult<Guid>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new BaseResult<Guid>(Guid.Empty, false, errorMessages);
            }

            // Falta validação de 90 dias

            var donor = await _unitOfWork.Donors.GetByIdAsync(request.DonorId);

            if (donor is null)
                return new BaseResult<Guid>(Guid.Empty, false, "Doador não encontrado.");

            if (!donor.IsDonorAdult())
                return new BaseResult<Guid>(Guid.Empty, false, "Doador deve ser maior de idade para doar.");

            var donationsByDonor = await _unitOfWork.Donations.GetByDonor(request.DonorId);

            if (donationsByDonor is not null)
            {
                var lastDonation = donationsByDonor.OrderByDescending(d => d.CreatedAt).First();
                if (lastDonation.IsLastDonationSufficientOld(donor.Gender))
                    return new BaseResult<Guid>(Guid.Empty, false, "Não houve tempo o suficiente desde a última doação.");
            }

            var donation = request.ToEntity(donor);
            await _unitOfWork.Donations.AddAsync(donation);

            var stock = new BloodStock(donor.BloodType, donor.RhFactor, donation.QuantityML);
            await _unitOfWork.BloodStocks.AddOrUpdateAsync(stock);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<Guid>(donation.Id);
        }
    }
}
