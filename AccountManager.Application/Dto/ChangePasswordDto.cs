using System;
namespace AccountManager.Application.Dto;

public class ChangePasswordDto
{
    public Guid Id { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

