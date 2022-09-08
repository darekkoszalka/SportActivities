using AccountManager.Application.Dto;

namespace AccountManager.Application.IServices;

public interface IRoleService
{
    Task<IList<RoleDto>> GetAll();
    Task Create(CreateRoleDto createRoleDto);
    Task Update(RoleDto roleDto);
    Task Delete(int roleId);
}

