using FluentValidation;
using DonorFlow.Application.Commands.DonorCommands.UpdateDonor;

namespace DonorFlow.Application.Validators
{
    public class UpdateDonorValidator : AbstractValidator<UpdateDonorCommand>
    {
        public UpdateDonorValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MinimumLength(2).WithMessage("O nome completo deve ser informado.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("O E-mail informado é inválido.");

            RuleFor(x => x.BirthDate)
            .NotEmpty()
            .LessThan(DateTime.Today).WithMessage("A data de nascimento não pode ser maior que a data atual.");

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("O Gênero informado é inválido.");

            RuleFor(x => x.Weight)
                .GreaterThan(50).WithMessage("O peso mínimo deve ser de 50KG.");

            RuleFor(x => x.BloodType)
                .IsInEnum().WithMessage("O Tipo Sanguíneo informado é inválido.");

            RuleFor(x => x.RhFactor)
                .IsInEnum().WithMessage("O Fator Rh informado é inválido.");

            RuleFor(x => x.CEP)
                .NotEmpty()
                .Matches(@"^\d{5}-\d{3}$").WithMessage("O CEP está em um formato inválido. Formadto esperado: 00000-000");
        }
    }
}
