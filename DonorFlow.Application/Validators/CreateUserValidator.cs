﻿using FluentValidation;
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
                .MinimumLength(2);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.CPF)
                .NotEmpty()
                .Custom((cpf, context) =>
                {
                    if (!Utils.IsCpfValid(cpf))
                    {
                        context.AddFailure("CPF", "CPF inválido.");
                    }
                });

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
