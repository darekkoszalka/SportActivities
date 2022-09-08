using System;
using System.Text.RegularExpressions;
using AccountManager.Application.Dto;
using AccountManager.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Infrastructure.Validations;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    private readonly Regex _passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\\W)(?!.* ).{8,16}$");

    public RegisterUserDtoValidator()
    {
        RuleFor(u => u.NickName)
            .NotEmpty()
            .WithMessage("That field is required.")
            .MaximumLength(50)
            .WithMessage("Max lenght: 50 characters.");
        //nick is taken
        RuleFor(u => u.NickName)
            .Custom(async (value, context) =>
        {
            if (await NickIsUse(value))
            {
                context.AddFailure("Nick", "That nick is taken.");
            }
        });

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("That field is required.")
            .EmailAddress()
            .WithMessage("Insert correct email.");

        RuleFor(u => u.Email)
            .Custom(async (value, context) =>
            {
                if (await EmailIsUse(value))
                {
                    context.AddFailure("That email is taken.");
                }
            });
        RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage("That field is required.");

        RuleFor(u=>u.Password)
            .Matches(_passwordRegex)
            .WithMessage("The password must contain at least 1 lowercase, 1 uppercase, 1 number and 1 special character. Length 8-16 characters.");

        RuleFor(u => u.ConfirmPassword)
            .Equal(u => u.Password)
            .WithMessage("Password and confirm password are not the same.");
        
    }

    private static async Task<bool> NickIsUse(string value)
    {
        using var context = new IdentityDbContext();
        return await context.Users.AnyAsync(u => u.NickName == value);     
    }

    private static async Task<bool> EmailIsUse(string value)
    {
        using var context = new IdentityDbContext();
        return await context.Users.AnyAsync(u => u.Email == value);
    }
}

