using System;
using AccountManager.Application.Dto;
using AccountManager.Application.IServices;
using AccountManager.Domain.Entities;
using AccountManager.Domain.IRepositories;
using AutoMapper;

namespace AccountManager.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(IRoleRepository roleRepository,
        IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task Create(CreateRoleDto createRoleDto)
    {
        var roleExists = await _roleRepository.RoleExists(createRoleDto.Name);
        if(roleExists is true)
        {
            throw new Exception("Role already exists.");
        }

        var role = _mapper.Map<Role>(createRoleDto);
        await _roleRepository.Create(role);
    }

    public Task Delete(int roleId)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<RoleDto>> GetAll()
    {
        var roles = await _roleRepository.GetAll();
        return _mapper.Map<IList<RoleDto>>(roles);
    }

    public Task Update(RoleDto roleDto)
    {
        throw new NotImplementedException();
    }
}

