using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
# nullable disable

namespace EcommerceWeb.Shared.Configuracion
{
	public class AppSettings
	{
		public Jwt Jwt { get; set; }
	}


	public class Jwt
	{
		public string SecretKey { get; set; }
		public string Emisor { get; set; }
		public string Audiencia { get; set; }
	}
}
