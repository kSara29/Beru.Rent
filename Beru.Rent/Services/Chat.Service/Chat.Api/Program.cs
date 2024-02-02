using Chat.Api.Hubs;
using Chat.Application;
using Chat.Application.Contracts;
using Chat.Application.Services;
using Chat.Infrastructure;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();
builder.Services.AddSignalR();

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

builder.Services.Configure<ChatDatabaseSettings>(
    builder.Configuration.GetSection("ConnectionStrings"));


builder.Services.AddSingleton<IChatDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<ChatDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));

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
