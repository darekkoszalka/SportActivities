using System;
using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Infrastructure.Data;

public class DataSeeder
{
    private readonly IdentityDbContext _context;

    public DataSeeder(IdentityDbContext context)
    {
        _context = context;
    }

    public async Task UseMigrations()
    {
        if(await _context.Database.CanConnectAsync())
        {
            if(_context.Database.GetPendingMigrations().Count() > 0)
            {
                await _context.Database.MigrateAsync();
            }
        }
    }

    public async Task AddRole()
    {
        if(await _context.Database.CanConnectAsync())
        {
            if (await _context.Roles.AnyAsync()) return;

            foreach(var role in Roles)
            {
                await _context.Roles.AddAsync(role);
            }

            await _context.SaveChangesAsync();
        }
    }

    public static List<Role> Roles = new()
    {
        new Role{ Name = "Admin"},
        new Role{ Name = "User"}
    };
}

