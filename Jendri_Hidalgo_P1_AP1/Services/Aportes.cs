using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Jendri_Hidalgo_P1_AP1.Models;
using Jendri_Hidalgo_P1_AP1.DAL;

namespace Jendri_Hidalgo_P1_AP1.Services
{
	public class AportesService
	{
		private readonly IDbContextFactory<Context> DbContextFactory;

		public AportesService(IDbContextFactory<Context> dbContextFactory)
		{
			DbContextFactory = dbContextFactory;
		}

		private async Task<bool> Existe(int AporteId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Aportes.AnyAsync(t => t.AporteId == AporteId);
		}

		private async Task<bool> Insertar(Aportes Aporte)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Aportes.Add(Aporte);
			return await context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Guardar(Aportes Aporte)
		{
			if (!await Existe(Aporte.AporteId))
			{
				return await Insertar(Aporte);
			}
			else
			{
				return await Modificar(Aporte);
			}
		}

		private async Task<bool> Modificar(Aportes Aporte)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Update(Aporte);
			return await context.SaveChangesAsync() > 0;
		}

		public async Task<Aportes?> Buscar(int IngresoId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Aportes
				.FirstOrDefaultAsync(t => t.AporteId == IngresoId);
		}

		public async Task<bool> Eliminar(int AporteId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Aportes
				.Where(t => t.AporteId == AporteId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>> criterio)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Aportes.Where(criterio).ToListAsync();
		}

		public async Task<Aportes?> BuscarPersona(string Personas)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Aportes
				.FirstOrDefaultAsync(e => e.Personas == Personas);
		}
	}
}
