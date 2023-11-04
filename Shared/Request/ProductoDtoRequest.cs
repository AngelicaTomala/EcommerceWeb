﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Shared.Request
{
	public class ProductoDtoRequest
	{
		public string Nombre { get; set; } = default!;
		public string Descripcion { get; set; } = default!;
		public decimal PrecioUnitario { get; set; }
		public int MarcaId { get; set; }
		public int CategoriaId { get; set; }
	}
}
