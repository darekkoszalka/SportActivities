using System;
using AccountManager.Domain.Entities;

namespace AccountManager.Domain.IRepositories;

public interface IRoleRepository
{
    Task<IList<Role>> GetAll();
    Task Create(Role role);
    Task Update(Role role);
    Task Delete(Role role);
    Task<bool> RoleExists(string roleName);
}

