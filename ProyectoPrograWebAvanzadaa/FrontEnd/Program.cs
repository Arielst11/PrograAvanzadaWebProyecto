using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IAsistenciaHelper, AsistenciaHelper>();
builder.Services.AddScoped<IClaseHelper, ClaseHelper>();
builder.Services.AddScoped<INotaHelper, NotaHelper>();
builder.Services.AddScoped<ITareaHelper, TareaHelper>();
builder.Services.AddScoped<ITipoUsuarioHelper, TipoUsuarioHelper>();
builder.Services.AddScoped<IUsuarioHelper, UsuarioHelper>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
