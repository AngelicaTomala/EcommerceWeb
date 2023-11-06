using EcommerceWeb.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.DataAccess
{
	public class UseDataSeeder
	{
		public static async Task Seed(IServiceProvider service)
		{
			//UserManager (Repositorio de usuario)
			var userManager = service.GetRequiredService<UserManager<IdentityUserECommerce>>();
			//Rolemanager (Repositorio de roles)
			var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();


			//Crear Roles
			var adminRole = new IdentityRole(Constantes.RolAdministrador);
			var clienteRole = new IdentityRole(Constantes.RolCliente);

			await roleManager.CreateAsync(adminRole);
			await roleManager.CreateAsync(clienteRole);

			//crear usuario administrador
			var adminUser = new IdentityUserECommerce()
			{
				NombreCompleto = "Administrador del sistema",
				FechaNacimeinto = DateTime.Parse("1990-01-01"),
				Direccion = "Bastion",
				UserName = "admin",
				Email = "admin@gmail.com",
				EmailConfirmed = true
			};

			var result = await userManager.CreateAsync(adminUser, "pas$$W0rD@123");

			if(result.Succeeded)
			{
				//esto me asegura que el usuario se creo correctamente
				adminUser = await userManager.FindByEmailAsync(adminUser.Email);

				if(adminUser is not null)
				{
					await userManager.AddToRoleAsync(adminUser, Constantes.RolAdministrador);
				}
			}
		}
	}
}
