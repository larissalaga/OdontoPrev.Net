using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Mappings;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Implementations;
using WebApplicationOdontoPrev.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Registrando o AutoMapper com o perfil de mapeamento
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache(); // Ensures caching for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set timeout for session data if needed
    options.Cookie.HttpOnly = true; // Makes the session cookie inaccessible to client-side scripts
    options.Cookie.IsEssential = true; // Ensures the session is always available
});
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
});
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IDentistaRepository, DentistaRepository>();
builder.Services.AddScoped<IPlanoRepository, PlanoRepository>();
builder.Services.AddScoped<IExtratoPontosRepository, ExtratoPontosRepository>();
builder.Services.AddScoped<IRaioXRepository, RaioXRepository>();
builder.Services.AddScoped<IAnaliseRaioXRepository, AnaliseRaioXRepository>();
builder.Services.AddScoped<ICheckInRepository, CheckInRepository>();
builder.Services.AddScoped<IPerguntasRepository, PerguntasRepository>();
builder.Services.AddScoped<IRespostasRepository, RespostasRepository>();
builder.Services.AddScoped<IPacienteDentistaRepository, PacienteDentistaRepository>();
builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

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
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PacienteHome}/{action=PacienteHome}/{id?}");*/

app.Run();
