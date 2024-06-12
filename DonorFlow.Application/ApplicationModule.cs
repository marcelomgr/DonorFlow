using MediatR;
using FluentValidation;
using DonorFlow.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using DonorFlow.Application.Commands.CreateUser;
using DonorFlow.Application.Commands.UpdateUser;
using DonorFlow.Application.Commands.CreateDonor;
using DonorFlow.Application.Commands.UpdateDonor;

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
            services.AddTransient<IValidator<CreateUserCommand>, CreateUserValidator>();
            services.AddTransient<IValidator<UpdateUserCommand>, UpdateUserValidator>();
            services.AddTransient<IValidator<CreateDonorCommand>, CreateDonorValidator>();
            services.AddTransient<IValidator<UpdateDonorCommand>, UpdateDonorValidator>();

            return services;
        }
    }
}
