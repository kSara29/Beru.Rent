using Ad.Api.DTO.Tarif;
using Ad.Api.Mapper;
using Ad.Application.Lib;
using Ad.Application.Lib.Contracts.Tarif;
using Ad.Infrastructure.Lib;
using Ad.Infrastructure.Lib.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ad.Application.Lib.Contracts.Tag;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService();
builder.Services.AddDbContext<AdContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();