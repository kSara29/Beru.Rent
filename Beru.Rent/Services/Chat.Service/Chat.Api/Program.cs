using Chat.Api.BackgroundServices;
using Chat.Api.Hubs;
using Chat.Application;
using Chat.Application.Contracts;
using Chat.Application.Services;
using Chat.Infrastructure;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddHostedService<RabbitMQConsumerHostedService>();

#region CORS политики

builder.Services.AddCors(options =>
{
    options.AddPolicy("mypolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader();
        
        builder.WithOrigins("https://localhost:3000");
    });
});

#endregion

builder.Services.Configure<ChatDatabaseSettings>(
    builder.Configuration.GetSection("ConnectionStrings"));


builder.Services.AddSingleton<IChatDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<ChatDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));

configureLoggin();
builder.Host.UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseCors("mypolicy");
app.MapHub<ChatHub>("/chatHub");

app.Run();


void configureLoggin()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile(
            $"appsettings.{environment}.json", optional: true
        ).Build();

    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithExceptionDetails()
        .WriteTo.Debug()
        .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
        .Enrich.WithProperty("Environment", environment)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}

ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
    return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
    {
        AutoRegisterTemplate = true,
        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
        NumberOfReplicas = 1,
        NumberOfShards = 2
    };
}