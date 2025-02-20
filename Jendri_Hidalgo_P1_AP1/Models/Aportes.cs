using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Jendri_Hidalgo_P1_AP1.Models
{
	public class Aportes
	{
		[Key]

		public int AporteId { get; set; }

		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo solo permite letras")]
		[Required(ErrorMessage = "Este campo es requerido")]
		public string Personas { get; set; }

		[RegularExpression(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚüÜñÑ.,\s]+$", ErrorMessage = "Solo se permiten letras, números, espacios y los caracteres .,")]
		[Required(ErrorMessage = "Este campo es requerido")]
		public string Observacion { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public decimal Monto { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public DateTime Fecha { get; set; } = DateTime.Now.Date;

	}
}
