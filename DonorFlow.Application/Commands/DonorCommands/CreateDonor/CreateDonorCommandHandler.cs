using MediatR;
using FluentValidation;
using DonorFlow.Core.Repositories;
using DonorFlow.Core.ValueObjects;
using DonorFlow.Application.Models;
using Microsoft.IdentityModel.Tokens;
using DonorFlow.Core.Integrations.ApiCepIntegration;

namespace DonorFlow.Application.Commands.DonorCommands.CreateDonor
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, BaseResult<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateDonorCommand> _validator;
        private readonly IApiCepService _apiCepService;

        public CreateDonorCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateDonorCommand> validator, IApiCepService apiCepService)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _apiCepService = apiCepService;
        }

        public async Task<BaseResult<Guid>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new BaseResult<Guid>(Guid.Empty, false, errorMessages);
            }

            var existingDonor = await _unitOfWork.Donors.GetByEmailAsync(request.Email.Trim());

            if (existingDonor is not null)
                return new BaseResult<Guid>(Guid.Empty, false, "Email já cadastrado.");

            var donor = request.ToEntity();

            if (request.CEP is not null && !request.CEP.IsNullOrEmpty())
            {
                var resultCep = await _apiCepService.GetByCep(request.CEP);

                if (resultCep is null)
                    return new BaseResult<Guid>(Guid.Empty, false, "CEP não encontrado.");

                var location = new LocationInfo(resultCep.Cep, resultCep.Logradouro, resultCep.Bairro, resultCep.Localidade, resultCep.UF);
                donor.SetLocation(location);
            }

            await _unitOfWork.Donors.AddAsync(donor);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<Guid>(donor.Id);
        }
    }
}
