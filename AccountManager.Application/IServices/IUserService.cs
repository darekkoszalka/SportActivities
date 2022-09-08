using System;
using AccountManager.Application.Dto;

namespace AccountManager.Application.IServices;

public interface IUserService
{
    Task<IList<UserDto>> GetAll();
    Task<UserDto> GetUserByEmail(string userEmail);
    Task<UserDto> GetUserById(Guid userId);
    Task Register(RegisterUserDto registerUserDto);
    Task ChangePassword(ChangePasswordDto changePasswordDto);
    Task Delete(Guid userId);
    Task<string> GenerateJWtToken();
}

