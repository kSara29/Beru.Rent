using Ad.Application;
using Ad.Infrastructure;
using Ad.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using Minio;



var builder = WebApplication.CreateBuilder(args);

#region подключаю DbContext для ADService

var connectionString = builder.Configuration.GetConnectionString("Postgres");
builder.Services.AddDbContext<AdContext>(options => options.UseNpgsql(connectionString));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

#endregion

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureServices();


#region Подключаю Minio
var minioConfig = builder.Configuration.GetSection("ConnectionStrings:Minio");

var endpoint = minioConfig["Endpoint"];
var accessKey = minioConfig["AccessKey"];
var secretKey = minioConfig["SecretKey"];

// Add Minio using the custom endpoint and configure additional settings for default MinioClient initialization
builder.Services.AddMinio(configureClient => configureClient
    .WithEndpoint(endpoint)
    .WithCredentials(accessKey, secretKey));
builder.Services.AddMinio(accessKey, secretKey);

// NOTE: SSL and Build are called by the build-in services already.
#endregion

builder.Services.AddApplicationService();
// builder.Services.AddDbContext<AdContext>(options =>
// {
//     options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
// });
builder.Services.AddControllers();
// Add Minio using the custom endpoint and configure additional settings for default MinioClient initialization

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();

