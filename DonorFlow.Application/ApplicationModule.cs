﻿using MediatR;
using FluentValidation;
using DonorFlow.Application.Services;
using DonorFlow.Application.Validators;
using DonorFlow.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using DonorFlow.Application.Commands.UserCommands.UpdateUser;
using DonorFlow.Application.Commands.UserCommands.CreateUser;
using DonorFlow.Application.Commands.DonorCommands.CreateDonor;
using DonorFlow.Application.Commands.DonorCommands.UpdateDonor;
using DonorFlow.Application.Commands.DonationCommands.CreateDonation;

namespace DonorFlow.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddMediator()
                .AddValidators();

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationModule));

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IEnumService, EnumService>();
            services.AddTransient<IValidator<CreateUserCommand>, CreateUserValidator>();
            services.AddTransient<IValidator<UpdateUserCommand>, UpdateUserValidator>();
            services.AddTransient<IValidator<CreateDonorCommand>, CreateDonorValidator>();
            services.AddTransient<IValidator<UpdateDonorCommand>, UpdateDonorValidator>();
            services.AddTransient<IValidator<CreateDonationCommand>, CreateDonationValidator>();
            return services;
        }
    }
}
