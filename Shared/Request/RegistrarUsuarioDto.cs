﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Shared.Request
{
	public class RegistrarUsuarioDto
	{
		[Required]
		public string NombreCompleto { get; set; } = default!;

        public DateTime FechaNacimiento { get; set; } = DateTime.Today.AddYears(-20);

        [Required]
        public string Direccion { get; set; } = default!;

		[Required]
		public string NombreUsuario { get; set; } = default!;

		[EmailAddress]
        public string Email { get; set; } = default!;

		[Required]
		public string Password { get; set; } = default!;

		[Compare(nameof(Password),ErrorMessage = "Las claves no coinciden.")]
		public string ConfirmPassword { get; set; } = default!;
	}
}
