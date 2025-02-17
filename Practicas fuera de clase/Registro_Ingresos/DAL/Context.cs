using Registro_Ingresos.Models;
using Microsoft.EntityFrameworkCore;

namespace Registro_Ingresos.DAL
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{
		}
		public DbSet<Ingresos> Ingresos { get; set; }
	}
	
}
