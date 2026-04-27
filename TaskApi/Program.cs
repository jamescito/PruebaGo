using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using Scalar.AspNetCore;
using TaskApi.Interfaces;
using TaskApi.Repositories;


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var builder = WebApplication.CreateBuilder(args);

<<<<<<< Updated upstream

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
=======
// --- 1. Configuración de CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("PruebaGoPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
>>>>>>> Stashed changes
    });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<DbPrueba>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

<<<<<<< Updated upstream
app.UseCors("AllowAngular");
=======
// --- 2. Middlewares (El orden es vital) ---
>>>>>>> Stashed changes

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Activar CORS antes de los controladores
app.UseCors("PruebaGoPolicy");

// Si tienes problemas de conexión, mantén esta línea comentada en desarrollo:
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();