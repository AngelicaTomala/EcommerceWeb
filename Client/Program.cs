using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using EcommerceWeb.Client;
using EcommerceWeb.Client.Auth;
using EcommerceWeb.Client.Proxy.Interfaces;
using EcommerceWeb.Client.Proxy.Services;
using ECommerceWeb.Client.Proxy.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//AddSingleton. -una sola instancia para la aplicacion
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredToast();
builder.Services.AddSweetAlert2();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();

//scopped es po sesion.- solo se crea una sola vez por sesion de usuario
builder.Services.AddScoped<IUserProxy, UserProxy>();
builder.Services.AddScoped<IProductoProxy, ProductoProxy>();
builder.Services.AddScoped<ICarritoProxy, CarritoProxy>();
builder.Services.AddScoped<IVentaProxy, VentaProxy>();

//habilitamos el contexto de seguridad en blazor
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationService>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
