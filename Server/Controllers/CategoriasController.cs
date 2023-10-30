using EcommerceWeb.Server.Entities;
using EcommerceWeb.Server.Repositiry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriasController : ControllerBase
	{
		//private readonly List<Categoria> _list;

		//public CategoriasController()
		//      {
		//	_list = new List<Categoria>()
		//		{
		//			new() { Id = 1, Nombre = "Celulares"},
		//			new() { Id = 2, Nombre = "Televisores"},
		//			new() { Id = 3, Nombre = "Electrodomésticos"},
		//		};
		//      }

		//[HttpGet]
		//public async Task<IActionResult> Get()
		//{
		//	//return Ok(await Task.FromResult(new List<Categoria>()));
		//	return Ok(await Task.FromResult(_list));
		//}

		private readonly ICategoriaRepository _repository;
		 public CategoriasController(ICategoriaRepository repository)
        {
                _repository = repository;  
        }

        [HttpGet]
		public async Task<IActionResult> Get()
		{
			//return Ok(await Task.FromResult(new List<Categoria>()));
			return Ok(await _repository.ListAsync());
		}

		[HttpPost]
		public async Task<IActionResult> Post(Categoria request)
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
		public async Task<IActionResult> Put(int id, Categoria request)
		{
			await _repository.UpdateAsync(id, request);
			return Ok();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _repository.DeleteAsync(id);
			return Ok();
		}
	}
}
