﻿using EcommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceWeb.DataAccess.Configurations
{
	public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
	{
		public void Configure(EntityTypeBuilder<Producto> builder)
		{
			builder.Property(p => p.Nombre)
				.HasMaxLength(150);

			builder.Property(p => p.Descripcion)
				.HasMaxLength(500);

			builder.Property(p => p.PrecioUnitario)
				.HasPrecision(11, 2);

			builder.Property(p => p.UrlImagen)
				.IsUnicode(false)
				.HasMaxLength(600);
		}
	}
}
