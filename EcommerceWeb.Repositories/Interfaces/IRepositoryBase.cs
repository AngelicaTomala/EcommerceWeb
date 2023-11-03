using EcommerceWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Repositories.Interfaces
{
	public interface IRepositoryBase<TEntity> where TEntity : EntityBase
	{
		Task<ICollection<TEntity>> ListAsync();
		Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity,bool>> predicado);
		Task<ICollection<TInfo>> ListAsync<TInfo>(Expression<Func<TEntity, bool>> predicado,
													Expression<Func<TEntity, TInfo>> selector,
													String relaciones);
		Task<TEntity?> FindAsync(int id);
		Task AddAsync(TEntity entity);
		Task UpdateAsync();
		Task DeleteAsync(int id);
	}
}
