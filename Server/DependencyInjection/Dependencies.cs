using EcommerceWeb.Repositories.Implementaciones;
using EcommerceWeb.Repositories.Interfaces;
using EcommerceWeb.Server.Perfiles;
using EcommerceWeb.Server.Services;
using System.Runtime.CompilerServices;

namespace EcommerceWeb.Server.DependencyInjection
{
	public static class Dependencies
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<ICategoriaRepository, CategoriaRepository>()//cada vez que se llama al api llega al servidor crea una nueva instancia por eso no se ve el cambio
																					   //builder.Services.AddScoped<ICategoriaRepository, CategoriaMemoryRepository>();//la api rest no tiene instancia
																					   //builder.Services.AddSingleton<ICategoriaRepository, CategoriaMemoryRepository>();//si hace el efecto de agregar porque utiliza la misma instancia para la aplicacion

			.AddTransient<IMarcaRepository, MarcaRepository>()
			.AddTransient<IProductoRepository, ProductoRepository>();

			return services;
		}

		public static IServiceCollection AddAutoMappers(this IServiceCollection services)
		{
			services.AddAutoMapper(config =>
			{
				config.AddProfile<ProductoProfile>();
			});

			return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			return services.AddTransient<IFileUploader, FileUploader>()
				.AddTransient<IUserService, UserService>();
		}
	}
}
