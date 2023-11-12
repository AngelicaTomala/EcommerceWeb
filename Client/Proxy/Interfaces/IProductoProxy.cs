using EcommerceWeb.Shared;

namespace EcommerceWeb.Client.Proxy.Interfaces
{
	public interface IProductoProxy
	{
		Task<ICollection<ProductoDto>> ListAsyn(string filtro);
	}
}
