using EcommerceWeb.Server.Entities;

namespace EcommerceWeb.Server.Repositiry
{
	public class CategoriaMemoryRepository : ICategoriaRepository
	{
		private List<Categoria> _list;
        public CategoriaMemoryRepository()
        {
				_list = new List<Categoria>()
				{
					new() {Id = 1, Nombre = "Celular de Alta Game", Comentarios = "Solo lo mas caro"},
					new() {Id = 2, Nombre = "Celular de Alta media", Comentarios = "Para todos los bolsillos"}
				};
        }
        public async Task AddAsync(Categoria entity)
		{
			entity.Id = _list.Count + 1;
			_list.Add(entity);
			await Task.FromResult(0);
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Categoria?> FindAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<ICollection<Categoria>> ListAsync()
		{
			return await Task.FromResult(_list);
		}

		public Task UpdateAsync(int id, Categoria entity)
		{
			throw new NotImplementedException();
		}
	}
}
