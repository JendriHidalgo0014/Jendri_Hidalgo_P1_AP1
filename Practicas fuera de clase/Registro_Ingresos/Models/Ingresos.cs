using System.ComponentModel.DataAnnotations;

namespace Registro_Ingresos.Models
{
	public class Ingresos
	{

		[Key]

		public int IngresoId { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
		public string Concepto { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		public decimal Monto { get; set; }


	}
}
