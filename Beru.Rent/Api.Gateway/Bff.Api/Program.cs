using Bff.Application;
using Bff.Application.JsonOptions;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;
using Serilog.Formatting.Elasticsearch;

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
            ValidateAudience = false,
            ClockSkew = TimeSpan.FromSeconds(15)
        };
        config.RequireHttpsMetadata = false;
        config.Authority = "https://localhost:7258";
    });
builder.Services.AddAuthorization();
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

configureLoggin();
builder.Host.UseSerilog();

var app = builder.Build();
app.UseFastEndpoints();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors("mypolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
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
        .WriteTo.File(
            path: $"logs/{environment}/{DateTime.Now.ToString("yyyy-MM-dd")}/{DateTime.Now.ToString("HH")}/log.txt",
            rollingInterval: RollingInterval.Hour,
            rollOnFileSizeLimit: true,
            retainedFileCountLimit: null,
            shared: true)
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
        CustomFormatter = new ElasticsearchJsonFormatter(inlineFields: true, renderMessageTemplate: false),
        NumberOfReplicas = 1,
        NumberOfShards = 2
    };
}