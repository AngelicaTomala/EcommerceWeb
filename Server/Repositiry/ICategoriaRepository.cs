using EcommerceWeb.Server.Entities;

namespace EcommerceWeb.Server.Repositiry
{
	public interface ICategoriaRepository
	{
		Task<ICollection<Categoria>> ListAsync();
		Task<Categoria?> FindAsync(int id);
		Task AddAsync(Categoria entity);
		Task UpdateAsync(int id, Categoria entity);
		Task DeleteAsync(int id);

	}
}
