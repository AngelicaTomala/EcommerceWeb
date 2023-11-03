using EcommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection;

public class EcommerceDbContext:DbContext
{
    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
            
    }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);



		//esto se comenta para colocarlo en el archivo CategoriaConfiguration
		//modelBuilder.Entity<Categoria>()
		//	.HasKey(p => p.Id); //Esta es la llave primaria

		//modelBuilder.Entity<Categoria>()
		//	.Property(p => p.Nombre)
		//	.HasMaxLength(200);

		//modelBuilder.Entity<Categoria>()
		//	.Property(p =>p.Comentarios)
		//	.HasMaxLength(500);

		////agregar valores por default que va a ir a la bd
		//var lista = new List<Categoria>()
		//{
		//	new() { Id = 1, Nombre = "Celulares"},
		//	new() { Id = 2, Nombre = "Televisores"},
		//	new() { Id = 3, Nombre = "Electrodomésticos"},
		//};

		////para inicializar la bd con los registros de arriba cuando se crea por primera vez
		//modelBuilder.Entity<Categoria>()
		//	.HasData(lista);

		//FLUENT API
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

	//este metodo sirve para establecer a manera general algo: por ejemplo que todos lo que sea definido como string sean varchar o 
	//que todos tengan un tipo de dato fijo
	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		base.ConfigureConventions(configurationBuilder);
		//configurationBuilder.Properties<string>().HaveColumnType("VARCHAR(100)");
		//configurationBuilder.Properties<string>().HaveMaxLength(100);


		//sirve para que cuando se hage un remove no se haga el cascade 
		configurationBuilder.Conventions.Remove(typeof(CascadeDeleteConvention));
	}
}