using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Shared.Response
{
	public class BaseResponse
	{
        public bool Exito { get; set; }
        public String? MensajeError { get; set; }
    }
}
