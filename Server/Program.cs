using EcommerceWeb.Repositories.Implementaciones;
using EcommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllersWithViews();//APP .NET MVC
//builder.Services.AddRazorPages(); // ASP .NET RAZOR PAGE

builder.Services.AddDbContext<EcommerceDbContext>(options => 
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDB"));
});

builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();//cada vez que se llama al api llega al servidor crea una nueva instancia por eso no se ve el cambio
//builder.Services.AddScoped<ICategoriaRepository, CategoriaMemoryRepository>();//la api rest no tiene instancia
//builder.Services.AddSingleton<ICategoriaRepository, CategoriaMemoryRepository>();//si hace el efecto de agregar porque utiliza la misma instancia para la aplicacion

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


//app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
