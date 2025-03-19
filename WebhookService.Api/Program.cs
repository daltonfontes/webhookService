using Microsoft.EntityFrameworkCore;
using WebhookService.Api.Configurations;
using WebhookService.Application.UseCases;
using WebhookService.Domain.Interfaces;
using WebhookService.Infrastructure.Context;
using WebhookService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var host = builder.Configuration["Database-Sql-Host"];
var user = builder.Configuration["Database-Sql-User"];
var password = builder.Configuration["Database-Sql-Password"];
var database = builder.Configuration["Database-Sql-Name"];
var connectionString = $"Server={host};Username={user};Database={database};Port=5432;Password={password};SSLMode=Prefer";
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

// Add environment variables
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddScoped<IWebhookRepository, InMemoryWebhookRepository>();
builder.Services.AddScoped<ProcessWebhookUseCase>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.RunMigration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();

public partial class Program { }
