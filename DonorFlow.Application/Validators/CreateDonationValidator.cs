using FluentValidation;
using DonorFlow.Application.Commands.DonationCommands.CreateDonation;

namespace DonorFlow.Application.Validators
{
    public class CreateDonationValidator : AbstractValidator<CreateDonationCommand>
    {
        public CreateDonationValidator()
        {
            RuleFor(x => x.QuantityML)
                .GreaterThan(420).LessThan(470).WithMessage("A quantidade deve estar entre 420ml e 470ml.");

            // Falta regra para maiores de idade

        }
    }
}
