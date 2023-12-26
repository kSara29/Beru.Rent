using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using User.Application;
using User.Application.Contracts;
using User.Application.DTO;
using User.Application.Extencions;
using User.Infrastructure;
using User.Infrastructure.Context;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService();
builder.Services.AddFastEndpoints();

builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
}).AddIdentity<User.Domain.Models.User, IdentityRole>(opt =>
    {
        opt.Password.RequiredLength = 6;
    }).AddEntityFrameworkStores<UserContext>();
var app = builder.Build();

app.UseFastEndpoints();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var userManager = services.GetRequiredService<UserManager<User.Domain.Models.User>>();
    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await Adminitializer.SeedAdminUserAsync(rolesManager, userManager);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while seeding the database.");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();

