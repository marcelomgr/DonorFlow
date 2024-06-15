using FluentValidation;
using DonorFlow.Utilities;
using DonorFlow.Application.Commands.UserCommands.UpdateUser;

namespace DonorFlow.Application.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MinimumLength(2).WithMessage("O nome completo deve ser informado.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("O E-mail informado é inválido.");

            RuleFor(x => x.CEP)
                .NotEmpty()
                .Matches(@"^\d{5}-\d{3}$").WithMessage("O CEP está em um formato inválido. Formadto esperado: 00000-000");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .Custom((cpf, context) =>
                {
                    if (!Utils.IsCpfValid(cpf))
                    {
                        context.AddFailure("CPF", "O CPF informado é inválido.");
                    }
                });

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("O Gênero informado é inválido.");

            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("A permissão informada é inválida.");

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
