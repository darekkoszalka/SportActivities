using System;
using AccountManager.Domain.Entities;
using AccountManager.Domain.IRepositories;
using AccountManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IdentityDbContext _context;

    public RoleRepository(IdentityDbContext context)
    {
        _context = context;
    }

    public async Task Create(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
    }

    public Task Delete(Role role)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Role>> GetAll()
    {
        return await _context.Roles
            .OrderBy(r => r.Name)
            .ToListAsync();
    }

    public async Task<bool> RoleExists(string roleName)
    {
        var roleExists = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        if (roleExists is null) return false;
        return true;
    }

    public async Task Update(Role role)
    {
        _context.Entry(role).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}

