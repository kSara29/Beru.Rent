using Ad.Application;
using Ad.Infrastructure;
using Ad.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using Minio;



var builder = WebApplication.CreateBuilder(args);

#region подключаю DbContext для ADService

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AdContext>(options => options.UseNpgsql(connectionString));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

#endregion

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region Подключаю Minio
var endpoint = "play.min.io";
var accessKey = "Q3AM3UQ867SPQQA43P2F";
var secretKey = "zuf+tfteSlswRu7BJ86wtrueekitnifILbZam1KYY3TG";

// Add Minio using the custom endpoint and configure additional settings for default MinioClient initialization
builder.Services.AddMinio(configureClient => configureClient
    .WithEndpoint(endpoint)
    .WithCredentials(accessKey, secretKey));
builder.Services.AddMinio(accessKey, secretKey);

// NOTE: SSL and Build are called by the build-in services already.
#endregion

builder.Services.AddApplicationService();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();
builder.Services.AddHttpClient();


// builder.Services.AddDbContext<AdContext>(options =>
// {
//     options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
// });
// Add Minio using the custom endpoint and configure additional settings for default MinioClient initialization

#region CORS политики

builder.Services.AddCors(options =>
{
    options.AddPolicy("mypolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseCors("mypolicy");


app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();

