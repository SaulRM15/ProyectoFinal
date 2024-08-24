using Microsoft.AspNetCore.Authentication.Cookies;
using ProyectoFinal.Application.Servicios;
using ProyectoFinal.Dominio.Interfaces;
using ProyectoFinal.Infraestructura.DBContext;
using ProyectoFinal.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar la conexión a la base de datos con Entity Framework
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Registrar los servicios y repositorios
//builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
//builder.Services.AddScoped<ISolicitudRepository, SolicitudRepository>();
//builder.Services.AddScoped<UsuarioService>();
//builder.Services.AddScoped<SolicitudService>();


//// Configurar la autenticación con cookies (o cualquier otro método de autenticación que prefieras)
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Account/Login";
//        options.AccessDeniedPath = "/Account/AccessDenied";
//    });

builder.Services.AddRazorPages();

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
