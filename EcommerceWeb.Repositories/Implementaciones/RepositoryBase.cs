using EcommerceWeb.Entities;
using EcommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Repositories.Implementaciones
{
	//abstractar para que no se pueda hacer un new, necesariamente debe haber una clase que herede de esta
	public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
	{
		//esta variable es para el acceso al dbcontext y se la coloca protected para que
		//se pueda utilizar en todas las clases que se hereden.
		protected readonly EcommerceDbContext context;

		//ambito proteted es para que se herede
		protected RepositoryBase(EcommerceDbContext _context)
        {
			context = _context;
		}
        public async Task AddAsync(TEntity entity)
		{
			await context.Set<TEntity>().AddAsync(entity);
			await context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var registro = await FindAsync(id);

			if(registro is not null)
			{
				registro.Estado = false;
				await UpdateAsync();
			}
		}

		public async Task<TEntity?> FindAsync(int id)
		{
			return await context.Set<TEntity>().FindAsync(id);			
		}

		public async Task<ICollection<TEntity>> ListAsync()
		{
			return await context.Set<TEntity>()
				.Where(p => p.Estado)
				.AsNoTracking() 
				.ToListAsync();
		}

		public async Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicado)
		{
			return await context.Set<TEntity>()
				.Where(predicado)
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<ICollection<TInfo>> ListAsync<TInfo>(Expression<Func<TEntity, bool>> predicado, Expression<Func<TEntity, TInfo>> selector, string relaciones)
		{
			var collection = context.Set<TEntity>()
				.Where(predicado)
				.AsQueryable();

			if(!string.IsNullOrEmpty(relaciones))
			{
                foreach (var tabla in relaciones.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
					collection = collection.Include(tabla);
                }
            }

				return await collection
					.AsNoTracking()
					.Select(selector)
					.ToListAsync();
		}

		public async Task UpdateAsync()
		{
			await context.SaveChangesAsync();
		}
	}
}
