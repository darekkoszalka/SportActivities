using System;
using Microsoft.Extensions.DependencyInjection;
using Running.Infrastructure.Data;

namespace Running.Infrastructure.Configurations.DependencyInjections;

public static class EntitiesDependency
{
    public async static Task<IServiceCollection> SeedData(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var context = serviceProvider.GetRequiredService<RunningDbContext>();
        RunningDbSeedData seeder = new(context);
        await seeder.UseMigrations();
        await seeder.AddTypeOfRun();
        return services;
    }
}

