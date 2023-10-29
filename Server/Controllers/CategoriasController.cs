using EcommerceWeb.Server.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriasController : ControllerBase
	{
		private readonly List<Categoria> _list;

		public CategoriasController()
        {
			_list = new List<Categoria>()
				{
					new() { Id = 1, Nombre = "Celulares"},
					new() { Id = 2, Nombre = "Televisores"},
					new() { Id = 3, Nombre = "Electrodomésticos"},
				};
        }

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			//return Ok(await Task.FromResult(new List<Categoria>()));
			return Ok(await Task.FromResult(_list));
		}
	}
}
