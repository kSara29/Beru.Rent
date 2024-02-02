using Bff.Application;
using Bff.Application.JsonOptions;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

#region CORS политики

builder.Services.AddCors(options =>
{
    options.AddPolicy("mypolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader();
        
        builder.WithOrigins("http://localhost:3000");
    });
});

#endregion
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints();
builder.Services.Configure<RequestToUserApi>(builder.Configuration.GetSection(RequestToUserApi.Name));
builder.Services.Configure<RequestToAdApi>(builder.Configuration.GetSection(RequestToAdApi.Name));
builder.Services.Configure<RequestToDealApi>(builder.Configuration.GetSection(RequestToDealApi.Name));
builder.Services.Configure<RequestToChatApi>(builder.Configuration.GetSection(RequestToChatApi.Name));
builder.Services.AddApplicationService();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
    {
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ClockSkew = TimeSpan.FromSeconds(5)
        };
        config.Authority = "https://localhost:7296";
    });
#region CORS политики

builder.Services.AddCors(options =>
{
    options.AddPolicy("mypolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader();
        
        builder.WithOrigins("http://localhost:3000");
    });
});

#endregion
var app = builder.Build();
app.UseFastEndpoints();
app.UseRouting();
app.UseCors("mypolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();