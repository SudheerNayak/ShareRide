using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using RideShare.Application.Interfaces;
using RideShare.Application.Interfaces.Repository;
using RideShare.Application.Interfaces.Services;
using RideShare.Application.Services;
using RideShare.Infrastructure.Data;
using RideShare.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Get connection string
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Db connection string is not found");

// Register framework services
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register DbContext
builder.Services.AddDbContext<RideShareDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Register repositories
builder.Services.AddScoped<IRideRepository, RideRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

// Register services
builder.Services.AddScoped<IRideService, RideService>();

// Register Unit of Work
builder.Services.AddScoped<IUnitOfWork, RideShareUnitOfWork>();

// Build application
var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();