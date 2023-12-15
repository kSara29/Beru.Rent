using Ad.Application.Lib;
using Ad.Application.Lib.DTO;
using Ad.Application.Lib.Services;
using Ad.Infrastructure.Lib;
using Ad.Infrastructure.Lib.Database;
using Microsoft.AspNetCore.Mvc;
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




app.MapPost("/ad/picture", ([FromBody] PictureDto dto, IPictureRepository service) => { });
app.Run();

