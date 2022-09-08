using System;
using AccountManager.Application.Dto;
using AccountManager.Domain.Entities;
using AutoMapper;

namespace AccountManager.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>()
        .ForMember(u => u.RoleName, r => r.MapFrom(r => r.Role.Name));
        CreateMap<UserDto, User>();
        CreateMap<RegisterUserDto, User>();
        CreateMap<ChangePasswordDto, User>();
        //Roles
        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
        CreateMap<CreateRoleDto, Role>();
    }
}

