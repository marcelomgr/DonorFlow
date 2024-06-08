using DonorFlow.Application.Commands.UpdateUser;
using DonorFlow.Core.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorFlow.Application.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.CEP)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.Role)
                .NotEmpty()
                .Must(role => Enum.TryParse<UserRole>(role, out _))
                .WithMessage("Role inválida");
        }
    }
}
