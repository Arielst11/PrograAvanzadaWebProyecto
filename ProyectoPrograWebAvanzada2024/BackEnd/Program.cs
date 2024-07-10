using DAL.Implementations;
using DAL.Interfaces;
using BackEnd.Services.Implementations;
using Entities.Entities;
using BackEnd.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region DI

builder.Services.AddDbContext<ColegiodbContext>();

builder.Services.AddScoped<ITareaDAL, TareaDALImpl>();
builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddScoped<IClaseDAL, ClaseDALImpl>();
builder.Services.AddScoped<IClaseService, ClaseService>();
builder.Services.AddScoped<IAsistenciasDAL, AsistenciasDALImpl>();
builder.Services.AddScoped<IAsistenciasService, AsistenciasService>();
builder.Services.AddScoped<INotaDAL, NotaDALImpl>();
builder.Services.AddScoped<INotaService, NotaService>();
builder.Services.AddScoped<ITipoUsuarioDAL, TipoUsuarioDALImpl>();
builder.Services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();


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
