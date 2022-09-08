using System;
using AccountManager.Application.Dto;
using AccountManager.Application.IServices;
using AccountManager.Application.Settings;
using AccountManager.Domain.Entities;
using AccountManager.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AccountManager.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;
    //private readonly AuthenticationSetting _authenticationSetting;

    public UserService(IUserRepository userRepository,
        IMapper mapper,
        IPasswordHasher<User> passwordHasher
        //AuthenticationSetting authenticationSetting
        )
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        //_authenticationSetting = authenticationSetting;
    }

    public async Task Delete(Guid userId)
    {
        var userExists = await _userRepository.GetUserById(userId);
        if(userExists is null)
        {
            throw new Exception("User doesn't exists.");
        }
        await _userRepository.Delete(userExists);
    }

    public Task<string> GenerateJWtToken()
    {
        throw new NotImplementedException();
    }

    public async Task<IList<UserDto>> GetAll()
    {
       
        var users = await _userRepository.GetAll();
        return _mapper.Map<IList<UserDto>>(users);
    }

    public Task<UserDto> GetUserByEmail(string userEmail)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task Register(RegisterUserDto registerUserDto)
    {
        var userExists = await _userRepository.UserExists(registerUserDto.Email);
        if(userExists is true)
        {
            throw new Exception("User already exists.");
        }

        var user = _mapper.Map<User>(registerUserDto);
        var hashPassword = _passwordHasher.HashPassword(user, registerUserDto.Password);
        user.PasswordHash = hashPassword;
        user.RegisterDate = DateTime.Now;
        await _userRepository.Register(user);

    }

    public async Task ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var userExists = await _userRepository.GetUserById(changePasswordDto.Id);
        if(userExists is null)
        {
            throw new Exception("User doesn't exists.");
        }

       var user = _mapper.Map(changePasswordDto, userExists);
        var hashPassword = _passwordHasher.HashPassword(user, changePasswordDto.Password);
        user.PasswordHash = hashPassword;
        user.UpdateDate = DateTime.Now;
        await _userRepository.Update(user);

        
    }
}

