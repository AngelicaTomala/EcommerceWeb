using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Shared
{
	public class CategoriaDto
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="El campo {0} es requerido.")]
		[StringLength(20)]
		public string Nombre { get; set; } = default!;
		public string? Comentarios { get; set; }
	}
}
