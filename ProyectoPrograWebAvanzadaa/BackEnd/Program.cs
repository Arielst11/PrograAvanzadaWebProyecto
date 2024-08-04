using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI

builder.Services.AddDbContext<Colegiodb2Context>();

builder.Services.AddScoped<ITareaDAL, TareaDALImpl>();
builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddScoped<IClaseDAL, ClaseDALImpl>();
builder.Services.AddScoped<IClaseService, ClaseService>();
builder.Services.AddScoped<IAsistenciaDAL, AsistenciaDALImpl>();
builder.Services.AddScoped<IAsistenciaService, AsistenciaService>();
builder.Services.AddScoped<INotaDAL, NotaDALImpl>();
builder.Services.AddScoped<INotaService, NotaService>();
builder.Services.AddScoped<ITipoUsuarioDAL, TipoUsuarioDALImpl>();
builder.Services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<IUsuarioDAL, UsuarioDALImpl>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

#endregion


var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
