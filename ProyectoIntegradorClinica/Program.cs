using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorClinica.Models;
using ProyectoIntegradorClinica.Servicios;
using SolAngeSolClinicaHealthla_sHealth.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión en el contenedor de dependencias
builder.Services.AddDbContext<AngelasHealthContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AngelasHealthDB"),
        sqlOptions => sqlOptions.MigrationsAssembly(typeof(AngelasHealthContext).Assembly.FullName)));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IRepositorioEspecialidades, RepositorioEspecialidades>();
builder.Services.AddTransient<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddTransient<IRepositorioCitas, RepositorioCitas>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
