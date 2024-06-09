using FluentValidation;
using DonorFlow.Utilities;
using DonorFlow.Core.Enums;
using DonorFlow.Application.Commands.UpdateUser;

namespace DonorFlow.Application.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.CEP)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.CPF)
                .NotEmpty()
                .Custom((cpf, context) =>
                {
                    if (!Utils.IsCpfValid(cpf))
                    {
                        context.AddFailure("CPF", "CPF inválido.");
                    }
                });

            RuleFor(x => x.Role)
                .NotEmpty()
                .Must(role => Enum.TryParse<UserRole>(role, out _))
                .WithMessage("Role inválida.");

            RuleFor(x => x.BirthDate)
            .NotEmpty()
            .Must(BeAnAdult)
            .WithMessage("Usuário deve ser maior de idade.");
        }

        private bool BeAnAdult(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}
