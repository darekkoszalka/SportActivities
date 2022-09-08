using System;
using System.Data;

namespace AccountManager.Application.Dto;

public class UserDto
{
    public Guid Id { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }
    public string RoleName { get; set; }
    
}

