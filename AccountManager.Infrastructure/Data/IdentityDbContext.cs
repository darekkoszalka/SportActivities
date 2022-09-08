using System;
using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Infrastructure.Data;

public class IdentityDbContext: DbContext
{
    private readonly string _connectionString = "Server=localhost;Database=ActivitiesIdentityDb;User=sa;Password=Docker@123;";
    public IdentityDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
    

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
}

