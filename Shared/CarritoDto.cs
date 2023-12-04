using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Shared
{
	public class CarritoDto
	{
		public ProductoDto ProductoDto { get; set; } = default!;

        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
		public decimal Total { get; set; }
	}
}
