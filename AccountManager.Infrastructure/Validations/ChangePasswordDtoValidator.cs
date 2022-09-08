using System;
using System.Text.RegularExpressions;
using AccountManager.Application.Dto;
using FluentValidation;

namespace AccountManager.Infrastructure.Validations
{
    public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
    {
        private readonly Regex _passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\\W)(?!.* ).{8,16}$");

        public ChangePasswordDtoValidator()
        {
            RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage("That field is required.");

            RuleFor(u => u.Password)
                .Matches(_passwordRegex)
                .WithMessage("The password must contain at least 1 lowercase, 1 uppercase, 1 number and 1 special character. Length 8-16 characters.");

            RuleFor(u => u.ConfirmPassword)
                .Equal(u => u.Password)
                .WithMessage("Password and confirm password are not the same.");

        }
    }
}

