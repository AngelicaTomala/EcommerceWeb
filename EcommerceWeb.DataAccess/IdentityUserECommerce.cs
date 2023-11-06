using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.DataAccess
{
	public class IdentityUserECommerce:IdentityUser
	{
        public string NombreCompleto { get; set; } = default!;
        public DateTime FechaNacimeinto { get; set; }
        public string Direccion { get; set; } = default!;
	}
}
