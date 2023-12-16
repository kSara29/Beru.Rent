using Ad.Api.DTO.Tarif;
using Ad.Api.Mapper;
using Ad.Application.Lib;
using Ad.Application.Lib.Contracts.Tarif;
using Ad.Infrastructure.Lib;
using Ad.Infrastructure.Lib.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ad.Application.Lib.Contracts.Tag;


using Ad.Application.Lib.DTO;
using Ad.Application.Lib.Services;
using Ad.Infrastructure.Lib.Database;
using Microsoft.AspNetCore.Http.HttpResults;
using Minio;

var endpoint = "play.min.io";
var accessKey = "Q3AM3UQ867SPQQA43P2F";
var secretKey = "zuf+tfteSlswRu7BJ86wtrueekitnifILbZam1KYY3TG";

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PictureDbContext>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureServices()
    .AddApplicationServices();
// Add Minio using the default endpoint
builder.Services.AddMinio(accessKey, secretKey);



builder.Services.AddApplicationService();
builder.Services.AddDbContext<AdContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});
builder.Services.AddControllers();
// Add Minio using the custom endpoint and configure additional settings for default MinioClient initialization
builder.Services.AddMinio(configureClient => configureClient
    .WithEndpoint(endpoint)
    .WithCredentials(accessKey, secretKey));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.MapControllers();




app.MapPost("/addpicture", ([FromBody] PictureDto dto, IPictureService service) =>
{
    service.SavePictureAnync(dto.PictureToModel());
    
});
app.Run();

