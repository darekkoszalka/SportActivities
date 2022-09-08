using System;
using AccountManager.Application.Dto;
using FluentValidation;

namespace AccountManager.Infrastructure.Validations;

public class CreateRoleRoleValidator : AbstractValidator<CreateRoleDto>
{
    public CreateRoleRoleValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage("This field is required.");
    }
}

