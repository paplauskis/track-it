using Domain.Interfaces.Data;
using Serilog;
using Infrastructure;
using Infrastructure.Data.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddInfrastructure(connectionString!);

builder.Services.AddScoped<ITypeEntityDataReader, SeedDataReader>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();