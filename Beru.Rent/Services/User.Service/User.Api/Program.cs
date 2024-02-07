using Common;
using DbMigrator;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User.Application;
using User.Application.Extencions;
using User.Infrastructure;
using User.Infrastructure.Context;
using FastEndpoints;
using User.Api.IdentityConfiguration;
using ValidationOptions = IdentityServer4.Configuration.ValidationOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService();
builder.Services.AddFastEndpoints();
builder.Services.AddHttpClient();

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

// Add services to the container.
builder.Services.AddIdentityServer(config =>
    {
        config.UserInteraction.LoginUrl = "/Account/Login";
        config.UserInteraction.LogoutUrl = "/Account/Logout";
    })
    .AddAspNetIdentity<User.Domain.Models.User>()
    .AddInMemoryClients(Configuration.GetClients())
    .AddInMemoryApiResources(Configuration.GetApiResources())
    .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
    .AddInMemoryApiScopes(Configuration.GetScopes())
    .AddDeveloperSigningCredential();

builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy", b =>
    {
        b.AllowAnyOrigin();
        b.AllowAnyMethod();
        b.AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseFastEndpoints();
using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
try
{
    Thread.Sleep(15000);
    var dbContext = scope.ServiceProvider.GetRequiredService<UserContext>();
    dbContext.Database.Migrate();
    Thread.Sleep(15000);
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
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

