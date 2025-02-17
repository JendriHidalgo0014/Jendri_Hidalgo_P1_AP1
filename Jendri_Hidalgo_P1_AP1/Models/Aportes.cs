using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Jendri_Hidalgo_P1_AP1.Models
{
	public class Aportes
	{
		[Key]

		public int AporteId { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public string Persona { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public string Observacion { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public decimal Monto { get; set; }

	}
}
