using System;
using Microsoft.EntityFrameworkCore;
using Running.Application.StaticData;

namespace Running.Infrastructure.Data;

public class RunningDbSeedData
{
    private readonly RunningDbContext _context;

    public RunningDbSeedData(RunningDbContext context)
    {
        _context = context;
    }

    public async Task UseMigrations()
    {
        if (_context.Database.CanConnect())
        {
            if (_context.Database.GetPendingMigrations().Count() > 0)
            {
                await _context.Database.MigrateAsync();
            }
        }
    }

    public async Task AddTypeOfRun()
    {
        if(_context.Database.CanConnect())
        {
            if(_context.TypesOfRun.Any())
            {
                return;
            }

            foreach(var item in TypeOfRunSD.TypeOfRunList)
            {
                await _context.TypesOfRun.AddAsync(item);
            }

            await _context.SaveChangesAsync();
        }
    }
   
}

