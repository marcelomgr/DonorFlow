using DonorFlow.Application.Commands.CreateDonor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorFlow.Application.Validators
{
    public class CreateDonorValidator : AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorValidator()
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
