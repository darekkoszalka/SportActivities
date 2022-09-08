using System.Text.Json.Serialization;
using AccountManager.Application.IServices;
using AccountManager.Application.Services;
using AccountManager.Domain.Entities;
using AccountManager.Domain.IRepositories;
using AccountManager.Infrastructure.Configuration.DependencyInjections;
using AccountManager.Infrastructure.Data;
using AccountManager.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddDbContext<IdentityDbContext>();
EntityDependency.SeedData(builder.Services).Wait();
ValidationsDependency.AddUserValidator(builder.Services);
builder.Services.AddScoped<IUserRepository, UserRepository >();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
    });

});
builder.Services.Configure<JsonOptions>(option =>
{
    option.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();

