using Blazored.SessionStorage;
using EcommerceWeb.Shared.Response;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace EcommerceWeb.Client.Auth
{
	public class AuthenticationService : AuthenticationStateProvider
	{
		private readonly ISessionStorageService _sessionStorageService;
		private readonly HttpClient _httpClient;

		private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

		public AuthenticationService(ISessionStorageService sessionStorageService, HttpClient httpClient)
        {
			_sessionStorageService = sessionStorageService;
			_httpClient = httpClient;
		}

		public async Task Authenticate(LoginDtoResponse? response)
		{
			ClaimsPrincipal claimsPrincipal;

			if(response is not null)
			{
				//Establecer al objeto HttpClient el token en el header
				_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Token);

				//Recuperamos los claims desde el token recibido
				var jwt = ParseToken(response);
				claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, authenticationType: "JWT"));

				//Guardamos la session
				await _sessionStorageService.SetItemAsync("session", response);

			}
			else
			{
				claimsPrincipal = _anonymous;
				await _sessionStorageService.RemoveItemAsync("session");
			}

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
		}

		private JwtSecurityToken ParseToken(LoginDtoResponse response)
		{
			var handler = new JwtSecurityTokenHandler();
			var token = handler.ReadJwtToken(response.Token);
			return token;
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var sessionUsuario = await _sessionStorageService.GetItemAsync<LoginDtoResponse>("session");

			if(sessionUsuario is null)
			{
				return await Task.FromResult(new AuthenticationState(_anonymous));
			}

			var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(ParseToken(sessionUsuario).Claims, authenticationType: "JWT"));

			return await Task.FromResult(new AuthenticationState(claimsPrincipal));
		}
	}
}
