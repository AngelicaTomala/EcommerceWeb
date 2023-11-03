using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Shared
{
	public class MarcaDTO
	{
        public int Id { get; set; }

        [Required]
		[StringLength(100)]
		public string Nombre { get; set; } = default!;
	}
}
