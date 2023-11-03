using EcommerceWeb.Entities;
using EcommerceWeb.Repositories.Interfaces;
using EcommerceWeb.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductosController : ControllerBase
	{
		private readonly IProductoRepository _repository;

		public ProductosController(IProductoRepository repository)
        {
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var lista = await _repository.ListAsync(p => p.Estado, x => new ProductoDto
			{
				Id = x.Id,
				Nombre = x.Nombre,
				PrecioUnitario = x.PrecioUnitario,
				Marca = x.Marca.Nombre,
				Categoria = x.Categoria.Nombre
			}, "Marca,Categoria");

			return Ok(lista);
		}
    }
}
