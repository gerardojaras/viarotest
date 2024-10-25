using Api;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ColegioContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase"));
});
builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddScoped<IGradoService, GradoService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();