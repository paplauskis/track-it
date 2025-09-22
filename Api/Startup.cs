using System.Reflection;
using Api.Middleware;
using Application.Interfaces;
using Application.Services.Item;
using Domain.Interfaces.Data;
using Domain.Interfaces.Repositories.Generic;
using Domain.Models;
using Serilog;
using Infrastructure;
using Infrastructure.Data.Seed;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddInfrastructure(connectionString!);

builder.Services.AddScoped<ITypeEntityDataReader, SeedDataReader>();
builder.Services.AddScoped<IReadRepository<ItemType>, ItemTypeRepository>();
builder.Services.AddScoped<IReadItemTypesService, ItemTypeService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();