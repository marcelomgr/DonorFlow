using MediatR;
using FluentValidation;
using DonorFlow.Core.Repositories;
using DonorFlow.Core.ValueObjects;
using DonorFlow.Application.Models;
using Microsoft.IdentityModel.Tokens;
using DonorFlow.Core.Integrations.ApiCepIntegration;

namespace DonorFlow.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResult<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateUserCommand> _validator;
        private readonly IApiCepService _apiCepService;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateUserCommand> validator, IApiCepService apiCepService)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _apiCepService = apiCepService;
        }

        public async Task<BaseResult<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new BaseResult<Guid>(Guid.Empty, false, errorMessages);
            }

            var existingUser = await _unitOfWork.Users.GetByEmailAsync(request.Email.Trim());

            if (existingUser is not null)
                return new BaseResult<Guid>(Guid.Empty, false, "Email já cadastrado.");

            var user = request.ToEntity();

            if (request.CEP is not null && !request.CEP.IsNullOrEmpty())
            {
                var resultCep = await _apiCepService.GetByCep(request.CEP);

                if (resultCep is null)
                    return new BaseResult<Guid>(Guid.Empty, false, "CEP não encontrado.");

                var location = new LocationInfo(resultCep.Cep, resultCep.Logradouro, resultCep.Bairro, resultCep.Localidade, resultCep.UF);
                user.SetLocation(location);
            }

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<Guid>(user.Id);
        }
    }
}
