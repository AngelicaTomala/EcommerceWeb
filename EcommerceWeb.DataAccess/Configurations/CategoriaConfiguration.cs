using EcommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EcommerceWeb.DataAccess.Configurations
{
	public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
	{
		public void Configure(EntityTypeBuilder<Categoria> builder)
		{
			builder
				.Property(p => p.Nombre)
			.HasMaxLength(200);

			builder
				.Property(p => p.Comentarios)
				.HasMaxLength(500);

			//agregar valores por default que va a ir a la bd
			var lista = new List<Categoria>()
		{
			new() { Id = 1, Nombre = "Celulares"},
			new() { Id = 2, Nombre = "Televisores"},
			new() { Id = 3, Nombre = "Electrodomésticos"},
		};

			//para inicializar la bd con los registros de arriba cuando se crea por primera vez
			builder.HasData(lista);
		}
	}
}
