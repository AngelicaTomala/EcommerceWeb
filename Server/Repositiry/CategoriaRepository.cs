using EcommerceWeb.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace EcommerceWeb.Server.Repositiry
{
	public class CategoriaRepository : ICategoriaRepository
	{
		private readonly EcommerceDbContext _context;

		public CategoriaRepository(EcommerceDbContext context)
        {
			_context = context;
		}
        public async Task AddAsync(Categoria entity)
		{
			//se puede utilizar cualquiera de los dos

			//agregado explicito
			//await _context.Set<Categoria>().AddAsync(entity);

			//agregado implicito
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var registro = await FindAsync(id);

			if (registro != null)
			{
				_context.Set<Categoria>().Remove(registro);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Categoria?> FindAsync(int id)
		{
			return await _context.Set<Categoria>()
				.FindAsync(id);
		}

		public async Task<ICollection<Categoria>> ListAsync()
		{
			return await _context.Set<Categoria>()
				.AsNoTracking() //para no hacer siguimiento
				.ToListAsync();
		}

		public async Task UpdateAsync(int id, Categoria entity)
		{
			var registro = await FindAsync(id);

			if (registro is not null) 
			{
				registro.Nombre = entity.Nombre;
				registro.Comentarios = entity.Comentarios;

				await _context.SaveChangesAsync();
			}
		}
	}
}
