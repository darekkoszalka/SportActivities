using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Running.Domain.Common;
using Running.Domain.Entities;

namespace Running.Infrastructure.Data;

public class RunningDbContext : DbContext
{
    private readonly string _connectionString = "Server=localhost;Database=RunningDb;User=sa;Password=Docker@123;";
    public RunningDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);

    }

    public DbSet<Training> Trainings { get; set; }
    public DbSet<Run> Runs { get; set; }
    public DbSet<TypeOfRun> TypesOfRun { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}

