using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region ConexioDB
builder.Services.AddDbContext<Colegiodb2Context>(options =>
                options.UseSqlServer
                                (builder.Configuration.GetConnectionString("DefaultConnection"))
                                );

builder.Services.AddDbContext<AuthDBContext>(options =>
                options.UseSqlServer
                                (builder.Configuration.GetConnectionString("DefaultConnection"))
                                );
#endregion


#region Identity
builder.Services.AddIdentityCore<Usuario>()
        .AddRoles<IdentityRole>()
            .AddTokenProvider<DataProtectorTokenProvider<Usuario>>("fide")
            .AddEntityFrameworkStores<AuthDBContext>()
            .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

});




#endregion


#region JWT


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

})

    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });




#endregion








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
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<IUsuarioDAL, UsuarioDALImpl>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITokenService, TokenService>();

#endregion


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 
app.UseMiddleware<ApiKeyManager>();  ///Este activa el API key

app.UseAuthentication();  // este activa la authentication

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();


    var roles = new[] { "Estudiante", "Profesor", "Admin" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var adminUser = await userManager.FindByEmailAsync("admin@example.com");
    if (adminUser == null)
    {
        adminUser = new Usuario
        {
            UserName = "admin",
            Email = "admin@example.com",
            Nombre = "Admin",
            PrimerApellido = "User",
            SegundoApellido = ""
        };
        var result = await userManager.CreateAsync(adminUser, "Admin@1234");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}

app.Run();
