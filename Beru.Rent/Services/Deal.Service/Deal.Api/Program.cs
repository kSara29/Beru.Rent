using Deal.Api.DTO.Deal;
using Deal.Api.Mapper;
using Deal.Application.Contracts.Deal;
using Deal.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Deal.Application;
using Deal.Infrastructure;
using FastEndpoints;
using Minio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationService();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DealContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Подключаю Minio
var endpoint = "play.min.io";
var accessKey = "Q3AM3UQ867SPQQA43P2F";
var secretKey = "zuf+tfteSlswRu7BJ86wtrueekitnifILbZam1KYY3TG";

builder.Services.AddMinio(accessKey, secretKey);
builder.Services.AddMinio(configureClient => configureClient
    .WithEndpoint(endpoint)
    .WithCredentials(accessKey, secretKey));
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.Run();
