using EcommerceWeb.Repositories.Implementaciones;
using EcommerceWeb.Repositories.Interfaces;
using EcommerceWeb.Server.DependencyInjection;
using EcommerceWeb.Server.Perfiles;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllersWithViews();//APP .NET MVC
//builder.Services.AddRazorPages(); // ASP .NET RAZOR PAGE

builder.Services.AddDbContext<EcommerceDbContext>(options => 
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDB"));
	options.EnableSensitiveDataLogging();//para habilitar y asu poder los datos que se envian
});

builder.Services.AddRepositories()
	.AddAutoMappers()
	.AddServices();



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
