using MediatR;
using FluentValidation;
using DonorFlow.Core.Enums;
using DonorFlow.Core.Repositories;
using DonorFlow.Core.ValueObjects;
using DonorFlow.Application.Models;
using DonorFlow.Core.Integrations.ApiCepIntegration;

namespace DonorFlow.Application.Commands.UpdateDonor
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, BaseResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateDonorCommand> _validator;
        private readonly IApiCepService _apiCepService;

        public UpdateDonorCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateDonorCommand> validator, IApiCepService apiCepService)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _apiCepService = apiCepService;
        }

        public async Task<BaseResult> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new BaseResult<Guid>(Guid.Empty, false, errorMessages);
            }

            var donor = await _unitOfWork.Donors.GetByIdAsync(request.Id);

            if (donor is null)
                return new BaseResult<Guid>(Guid.Empty, false, "Doador não encontrado.");

            if (donor.Email != request.Email)
            {
                var existingDonor = await _unitOfWork.Donors.GetByEmailAsync(request.Email);

                if (existingDonor is not null)
                    return new BaseResult<Guid>(Guid.Empty, false, "Email já cadastrado.");
            }

            if (donor.Location?.Cep != request.CEP)
            {
                var resultCep = await _apiCepService.GetByCep(request.CEP);

                if (resultCep is null)
                    return new BaseResult<Guid>(Guid.Empty, false, "CEP não encontrado.");

                var location = new LocationInfo(resultCep.Cep, resultCep.Logradouro, resultCep.Bairro, resultCep.Localidade, resultCep.UF);
                donor.SetLocation(location);
            }

            donor.Update(
                request.FullName,
                request.Email,
                request.BirthDate,
                Enum.Parse<Gender>(request.Gender.ToString()),
                request.Weight,
                request.BloodType,
                Enum.Parse<RhFactor>(request.RhFactor.ToString()),
                donor.Location);

            await _unitOfWork.Donors.UpdateAsync(donor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new BaseResult();
        }
    }
}
