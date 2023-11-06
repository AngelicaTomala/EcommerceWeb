using EcommerceWeb.Shared.Request;
using EcommerceWeb.Shared.Response;

namespace EcommerceWeb.Server.Services
{
	public interface IUserService
	{
		Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request);
		Task<BaseResponse> RegisterAsync(RegistrarUsuarioDto request);
	}
}
