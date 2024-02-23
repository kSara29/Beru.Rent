using FastEndpoints;
using Notification.Api;
using Notification.Application;
using Notification.Application.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddFastEndpoints();
builder.Services.Configure<EmailSenderOptions>(builder.Configuration.GetSection("EmailSenderOptions"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFastEndpoints();
app.UseHttpsRedirection();

app.Run();