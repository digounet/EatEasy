using EatEasy.Infra.Data.Context;
using EatEasy.Services.API.Configurations;
using System.Reflection;
using EatEasy.Domain.Models;
using EatEasy.Infra.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// WebAPI Config
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setting DBContexts
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// ASP.NET Identity Settings & JWT
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddAuthenticationConfiguration();

// AutoMapper Settings
builder.Services.AddAutoMapperConfiguration();

// Swagger Config
builder.Services.AddSwaggerConfiguration();

// Adding MediatR for Domain Events and Notifications
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());

// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseReDoc(c =>
{
    c.DocumentTitle = "EatEasy API Documentation";
    c.SpecUrl = "/swagger/v1/swagger.json";
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<EatEasyContext>();

    if (context != null)
    {
        context.Database.Migrate();
        context.SeedCategoriesData();
        context.SeedProductsData();
    }

    var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
    var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

    if (userManager != null && roleManager != null)
    {
        await SeedIdentity.SeedIdentityData(userManager, roleManager);
    }
}

app.Run();
