using EcommerceWeb.DataAccess;
using EcommerceWeb.Repositories.Implementaciones;
using EcommerceWeb.Repositories.Interfaces;
using EcommerceWeb.Server.DependencyInjection;
using EcommerceWeb.Server.Perfiles;
using EcommerceWeb.Shared.Configuracion;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllersWithViews();//APP .NET MVC
//builder.Services.AddRazorPages(); // ASP .NET RAZOR PAGE


//leer el archivo de configuracion y lo traslada a un objeto fuertemente tipado
builder.Services.Configure<AppSettings>(builder.Configuration);

builder.Services.AddDbContext<EcommerceDbContext>(options => 
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDB"));
	options.EnableSensitiveDataLogging();//para habilitar y asu poder los datos que se envian
});

//Configuramos ASP .Net Identity
builder.Services.AddIdentity<IdentityUserECommerce, IdentityRole>(policies =>
{
	policies.Password.RequireDigit = false;
	policies.Password.RequireUppercase = true;
	policies.Password.RequireLowercase = false;
	policies.Password.RequireNonAlphanumeric = true;
	policies.Password.RequiredLength = 0;

	policies.User.RequireUniqueEmail = true;

	//TODO: politicas de bloqueos de cuentas

})
	//con esta linea indicamos cual es el dbcontext
	.AddEntityFrameworkStores<EcommerceDbContext>()
	//para que el token sea automatico para el reseto de password
	.AddDefaultTokenProviders();

builder.Services.AddRepositories()
	.AddAutoMappers()
	.AddServices();

builder.Services.AddControllers();

//para inyectar swagger
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo()
	{
		Title ="Ecommerce API REST",
		Version = "v1"
	});
});

//configuramos el contexto de seguridad del API
builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(X =>
{
	var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"] ??
											throw new InvalidOperationException("No se configuro el Secretkey"));

	X.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Jwt:Emisor"],
		ValidAudience = builder.Configuration["Jwt:Audiencia"],
		IssuerSigningKey = new SymmetricSecurityKey(secretKey)
	};
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();

	//cuando se abra la api rest se abra swagger
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce API V1");
		c.RoutePrefix = "swagger";
		c.DocumentTitle = "Documentacion de la API REST";
		c.DocExpansion(DocExpansion.List);
	});
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

//autenticacion
app.UseAuthentication();
//autorizacion (permisos)
app.UseAuthorization();

//app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

using(var scope = app.Services.CreateScope())
{
	await UseDataSeeder.Seed(scope.ServiceProvider);
}


app.Run();
