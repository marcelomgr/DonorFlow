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
                .MinimumLength(2);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
