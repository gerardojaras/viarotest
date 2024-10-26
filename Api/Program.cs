using System.Text.Json.Serialization;
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
builder.Services.AddScoped<IGradoAlumnoService, GradoAlumnoService>();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();