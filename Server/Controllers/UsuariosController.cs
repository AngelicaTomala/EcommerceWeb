using EcommerceWeb.Server.Services;
using EcommerceWeb.Shared.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Server.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UsuariosController : ControllerBase
	{
		private readonly IUserService _service;
		private readonly ILogger<UsuariosController> _logger;

		public UsuariosController(IUserService service, ILogger<UsuariosController> logger)
        {
			_service = service;
			_logger = logger;
		}

		//POST: api/Usuarios/login
		[HttpPost]
		public async Task<IActionResult> Login(LoginDtoRequest request)
		{
			var response = await _service.LoginAsync(request);

			_logger.LogInformation("Se inicio sesión desde {RequestID}", HttpContext.Connection.Id);
			return response.Exito ? Ok(response) : Unauthorized(response);
		}

		//POST: api/Usuarios/Register
		[HttpPost]
		public async Task<IActionResult>Register(RegistrarUsuarioDto request)
		{
			var response = await _service.RegisterAsync(request);

			//return response.Exito ? Ok(response) : BadRequest(response);
			return Ok(response);
		}
    }
}
