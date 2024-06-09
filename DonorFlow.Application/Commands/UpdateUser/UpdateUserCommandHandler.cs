using MediatR;
using FluentValidation;
using DonorFlow.Core.Enums;
using DonorFlow.Core.Repositories;
using DonorFlow.Core.ValueObjects;
using DonorFlow.Application.Models;
using DonorFlow.Core.Integrations.ApiCepIntegration;

namespace DonorFlow.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateUserCommand> _validator;
        private readonly IApiCepService _apiCepService;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateUserCommand> validator, IApiCepService apiCepService)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _apiCepService = apiCepService;
        }

        public async Task<BaseResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new BaseResult<Guid>(Guid.Empty, false, errorMessages);
            }

            var user = await _unitOfWork.Users.GetByIdAsync(request.Id);

            if (user is null)
                return new BaseResult<Guid>(Guid.Empty, false, "Usuário não encontrado.");

            if (user.Email != request.Email)
            {
                var existingUser = await _unitOfWork.Users.GetByEmailAsync(request.Email);

                if (existingUser is not null)
                    return new BaseResult<Guid>(Guid.Empty, false, "CPF já cadastrado.");
            }

            //if (!request.Password.IsNullOrEmpty())
            //    user.SetPassword();

            if (user.Location?.Cep != request.CEP)
            {
                var resultCep = await _apiCepService.GetByCep(request.CEP);

                if (resultCep is null)
                    return new BaseResult<Guid>(Guid.Empty, false, "CEP não encontrado.");

                var location = new LocationInfo(resultCep.Cep, resultCep.Logradouro, resultCep.Bairro, resultCep.Localidade, resultCep.UF);
                user.SetLocation(location);
            }

            user.Update(
                request.FullName,
                request.CPF,
                request.Email,
                user.Password,
                request.BirthDate,
                Enum.Parse<Gender>(request.Gender.ToString()),
                Enum.Parse<UserRole>(request.Role.ToString()),
                user.Location);

            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new BaseResult();
        }
    }
}
