using System;
using FluentValidation;
using Running.Application.Dto;

namespace Running.Infrastructure.Validations;

public class TrainigCreateDtoValidator :AbstractValidator<TrainingCreateDto>
{
    public TrainigCreateDtoValidator()
    {
        RuleFor(t => t.TrainingDate)
            .NotEmpty()
            .WithMessage("The field 'training date' is required.");

        RuleFor(t => t.TrainingDate)
            .Custom((value, context) =>
            {
            if (value > DateTime.Now)
                {
                    context.AddFailure("Training date cannot be from the future.");
                }
            });
            
        
        RuleFor(t => t.UserId)
            .NotEmpty()
            .WithMessage("User id is required");

        RuleFor(t => t.Runs[0].TypeOfRunId)
            .NotEmpty()
            .WithMessage("Type of run is required");
    }
}

