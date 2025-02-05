using FluentValidation;
using DonorFlow.Utilities;
using DonorFlow.Application.Commands.UserCommands.CreateUser;

namespace DonorFlow.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MinimumLength(2).WithMessage("O nome completo deve ser informado.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(5).WithMessage("A senha deve ser informada.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("O E-mail informado é inválido.");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .Custom((cpf, context) =>
                {
                    if (!cpf.IsCpfValid())
                    {
                        context.AddFailure("CPF", "O CPF informado é inválido.");
                    }
                });

            RuleFor(x => x.BirthDate)
            .NotEmpty()
            .Must(BeAnAdult)
            .WithMessage("Usuário deve ser maior de idade.")
            .LessThan(DateTime.Today).WithMessage("A data de nascimento não pode ser maior que a data atual.");
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
