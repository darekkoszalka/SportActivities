using System;
using AccountManager.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManager.Infrastructure.Configuration.DependencyInjections;

public static class EntityDependency
{
    public async static Task<IServiceCollection> SeedData(this IServiceCollection services)
    {
        var serviceProwider = services.BuildServiceProvider();
        var context = serviceProwider.GetRequiredService<IdentityDbContext>();
        DataSeeder seeder = new(context);
        await seeder.UseMigrations();
        await seeder.AddRole();
        return services;
    }
}

