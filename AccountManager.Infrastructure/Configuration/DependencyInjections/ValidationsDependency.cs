using System;
using AccountManager.Application.Dto;
using AccountManager.Infrastructure.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManager.Infrastructure.Configuration.DependencyInjections;

public static class ValidationsDependency
{
    public static IServiceCollection AddUserValidator(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
        services.AddScoped<IValidator<ChangePasswordDto>, ChangePasswordDtoValidator>();
        services.AddScoped<IValidator<CreateRoleDto>, CreateRoleRoleValidator>();
        return services;
    }
}

