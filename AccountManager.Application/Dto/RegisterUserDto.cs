using System;
namespace AccountManager.Application.Dto;

public class RegisterUserDto
{
    public int RoleId { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

