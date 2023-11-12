using EcommerceWeb.Client.Proxy.Interfaces;
using EcommerceWeb.Shared.Request;
using EcommerceWeb.Shared.Response;
using System.Net.Http.Json;
using System.Security;

namespace EcommerceWeb.Client.Proxy.Services
{
	public class UserProxy : IUserProxy
	{
		private readonly HttpClient _httpClient;

		public UserProxy(HttpClient httpClient)
        {
			_httpClient = httpClient;
		}
        public async Task<LoginDtoResponse> Login(LoginDtoRequest request)
		{
			var response = await _httpClient.PostAsJsonAsync("api/Usuarios/Login", request);
			
			var loginResponse = await response.Content.ReadFromJsonAsync<LoginDtoResponse>();

			return loginResponse!;
			}

		public async Task Register(RegistrarUsuarioDto request)
		{
			var response = await _httpClient.PostAsJsonAsync("api/Usuarios/Register", request);
			//solo en caso de que no sepa el error en el backend
			//response.EnsureSuccessStatusCode();

			if (response.IsSuccessStatusCode)
			{
				var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();

				if (resultado!.Exito == false)
				{
					throw new InvalidOperationException(resultado.MensajeError);
				}
			}
			else
				throw new InvalidOperationException(response.ReasonPhrase);
		}
	}
}
