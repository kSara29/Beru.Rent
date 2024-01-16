using System.Security.Claims;
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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService();
builder.Services.AddFastEndpoints();

// builder.Services.AddAuthentication(config =>
//     {
//         config.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//         config.DefaultChallengeScheme = "oidc";
//     })
//     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
//     .AddOpenIdConnect("oidc", config =>
//     {
//         config.Authority = "https://localhost:7114";
//         config.ClientId = "client_id_mvc";
//         config.ClientSecret = "client_secret_mvc";
//         config.SaveTokens = true;
//         config.ResponseType = "code";
//         config.GetClaimsFromUserInfoEndpoint = true;
//         config.Scope.Add("User.Api");
//     });

builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
}).AddIdentity<User.Domain.Models.User, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
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

