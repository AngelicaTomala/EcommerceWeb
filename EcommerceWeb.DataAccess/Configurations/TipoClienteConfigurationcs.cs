using EcommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceWeb.DataAccess.Configurations
{
	public class TipoClienteConfigurationcs : IEntityTypeConfiguration<TipoCliente>
	{
		public void Configure(EntityTypeBuilder<TipoCliente> builder)
		{
			builder.Property(p => p.Descripcion)
				.HasMaxLength(70);

			builder.HasData(new List<TipoCliente>
			{
				new() {Id = 1, Descripcion="Cliente Normal"},
				new() {Id = 2, Descripcion="Cliente Especial"},
			});
		}
	}
}
