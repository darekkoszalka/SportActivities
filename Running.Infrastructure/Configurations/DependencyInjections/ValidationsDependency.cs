using System;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Running.Application.Dto;
using Running.Infrastructure.Validations;

namespace Running.Infrastructure.Configurations.DependencyInjections;

public static class ValidationsDependency
{
    public static IServiceCollection AddTrainingValidations(this IServiceCollection services)
    {
        services.AddScoped <IValidator<TrainingCreateDto>, TrainigCreateDtoValidator>();

        return services;
    }
    
}

