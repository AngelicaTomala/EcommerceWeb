using AutoMapper;
using EcommerceWeb.Entities;
using EcommerceWeb.Repositories.Interfaces;
using EcommerceWeb.Server.Services;
using EcommerceWeb.Shared;
using EcommerceWeb.Shared.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductosController : ControllerBase
	{
		private readonly IProductoRepository _repository;
		private readonly IMapper _mapper;
		private readonly IFileUploader _fileUploader;

		public ProductosController(IProductoRepository repository, IMapper mapper, IFileUploader FileUploader)
		{
			_repository = repository;
			_mapper = mapper;
			_fileUploader = FileUploader;
		}

		[HttpGet]
		public async Task<IActionResult> Get(string? filtro)
		{
			var lista = await _repository.ListAsync(
				predicado: p => p.Estado && p.Nombre.Contains(filtro ?? string.Empty),
				selector: x => new ProductoDto
				{
					Id = x.Id,
					Nombre = x.Nombre,
					PrecioUnitario = x.PrecioUnitario,
					Marca = x.Marca.Nombre,
					Categoria = x.Categoria.Nombre
				}, "Marca,Categoria");

			return Ok(lista);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get(int id)
		{
			var response = await _repository.FindAsync(id);

			return response == null ? NotFound() : Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Post(ProductoDtoRequest request)
		{
			//mapeo manual
			//var producto = new Producto
			//{
			//	Nombre = request.Nombre,
			//	Descripcion = request.Descripcion,
			//	PrecioUnitario = request.PrecioUnitario,
			//	MarcaId = request.MarcaId,
			//	CategoriaId = request.CategoriaId,
			//};

			var producto = _mapper.Map<Producto>(request);
			producto.UrlImagen = await _fileUploader.UploadFileAsync(request.Base64Imagen, request.NombreArchivo);

			await _repository.AddAsync(producto);
			return Ok();
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Put(int id, ProductoDtoRequest request)
		{
			var registro = await _repository.FindAsync(id);

			if (registro is null)
			{
				return NotFound();
			}

			//mapeo manual
			//registro.Nombre = request.Nombre;
			//registro.Descripcion = request.Descripcion;
			//registro.CategoriaId = request.CategoriaId;
			//registro.MarcaId = request.MarcaId;
			//registro.PrecioUnitario = request.PrecioUnitario;

			if(!string.IsNullOrWhiteSpace(request.Base64Imagen))
			{
				if (string.IsNullOrWhiteSpace(registro.UrlImagen))
				{
					registro.UrlImagen = await _fileUploader.UploadFileAsync(request.Base64Imagen, request.NombreArchivo);
				}
				else
				{
					registro.UrlImagen = await _fileUploader.UploadFileAsync(request.Base64Imagen, request.NombreArchivo);
				}				
			}

			_mapper.Map(request, registro);

			await _repository.UpdateAsync();

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
