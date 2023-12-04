using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Shared.Request
{
    public class TarjetaDto
    {
        [Required(ErrorMessage = "Ingrese Titular")]
        public string? Titular { get; set; }

        [RegularExpression(@"^\d{4}-\d{4}-\d{4}-\d{4}$", ErrorMessage = "Ingrese una tarjeta valida")]
        public string? Numero { get; set; }

        [Required(ErrorMessage = "Ingrese Vigencia")]
        [MaxLength(5)]
        public string? Vigencia { get; set; }

        [Required(ErrorMessage = "Ingrese CVV")]
        [MaxLength(3)]
        public string? Cvv { get; set; }
    }
}
