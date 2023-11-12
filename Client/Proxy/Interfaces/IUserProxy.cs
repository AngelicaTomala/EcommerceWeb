using EcommerceWeb.Shared.Request;
using EcommerceWeb.Shared.Response;

namespace EcommerceWeb.Client.Proxy.Interfaces
{
	public interface IUserProxy
	{
		Task<LoginDtoResponse> Login(LoginDtoRequest request);

		Task Register(RegistrarUsuarioDto request);
	}
}
