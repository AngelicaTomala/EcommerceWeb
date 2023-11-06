using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.DataAccess.Configurations
{
	public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUserECommerce>
	{
		public void Configure(EntityTypeBuilder<IdentityUserECommerce> builder)
		{
			builder.Property(p => p.NombreCompleto)
				.HasMaxLength(200);

			builder.Property(p => p.FechaNacimeinto)
				.HasColumnType("DATE");

			builder.Property(p => p.Direccion)
				.HasMaxLength(500);

		}
	}
}
