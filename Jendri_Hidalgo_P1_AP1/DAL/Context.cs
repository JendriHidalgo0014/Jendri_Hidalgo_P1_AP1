using Microsoft.EntityFrameworkCore;
using Jendri_Hidalgo_P1_AP1.Models;

namespace Jendri_Hidalgo_P1_AP1.DAL
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{
		}
		public DbSet<Aportes> Aportes { get; set; }
	}
}

