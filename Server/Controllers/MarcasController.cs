using EcommerceWeb.Entities;
using EcommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MarcasController : ControllerBase
	{
		private readonly IMarcaRepository _repository;
		public MarcasController(IMarcaRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _repository.ListAsync());
		}

		[HttpPost]
		public async Task<IActionResult> Post(Marca request)
		{
			await _repository.AddAsync(request);
			return Ok();
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await _repository.FindAsync(id));
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Put(int id, Marca request)
		{
			var registro = await _repository.FindAsync(id);

			if (registro is null)
			{
				return NotFound();
			}

			registro.Nombre = request.Nombre;
			
			await _repository.UpdateAsync();

			return Ok();

			//await _repository.UpdateAsync(id, request);
			//return Ok();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _repository.DeleteAsync(id);
			return Ok();
		}
	}
}
