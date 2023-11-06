using EcommerceWeb.Server.Services;
using EcommerceWeb.Shared.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Server.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class usuariosController : ControllerBase
	{
		private readonly IUserService _service;

		public usuariosController(IUserService service)
        {
			_service = service;
		}

		//POST: api/Usuarios/login
		[HttpPost]
		public async Task<IActionResult> Login(LoginDtoRequest request)
		{
			var response = await _service.LoginAsync(request);
			return response.Exito ? Ok(response) : Unauthorized(response);
		}
    }
}
