using EcommerceWeb.Server.Entities;
using Microsoft.EntityFrameworkCore;

public class EcommerceDbContext:DbContext
{
    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
            
    }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Categoria>()
			.HasKey(p => p.Id); //Esta es la llave primaria

		modelBuilder.Entity<Categoria>()
			.Property(p => p.Nombre)
			.HasMaxLength(200);

		modelBuilder.Entity<Categoria>()
			.Property(p =>p.Comentarios)
			.HasMaxLength(500);

		//agregar valores por default que va a ir a la bd
		var lista = new List<Categoria>()
		{
			new() { Id = 1, Nombre = "Celulares"},
			new() { Id = 2, Nombre = "Televisores"},
			new() { Id = 3, Nombre = "Electrodomésticos"},
		};

		//para inicializar la bd con los registros de arriba cuando se crea por primera vez
		modelBuilder.Entity<Categoria>()
			.HasData(lista);
	}
}