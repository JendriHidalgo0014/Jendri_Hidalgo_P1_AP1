using Microsoft.EntityFrameworkCore;
using Registro_Ingresos.Models;
using Registro_Ingresos.DAL;
using System.Linq.Expressions;

namespace Registro_Ingresos.Services
{
	public class IngresosService(IDbContextFactory<Context> DbContextFactory)
	{

		private async Task<bool> Existe(int IngresoId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Ingresos.AnyAsync(t => t.IngresoId == IngresoId);

		}

		private async Task<bool> Insertar(Ingresos Ingresos)
		{

			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Ingresos.Add(Ingresos);
			return await context.SaveChangesAsync() > 0;

		}


		public async Task<bool> Guardar(Ingresos Ingresos)
		{
			if (!await Existe(Ingresos.IngresoId))
			{
				return await Insertar(Ingresos);
			}
			else
			{
				return await Modificar(Ingresos);
			}
		}



		private async Task<bool> Modificar(Ingresos Ingresos)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			context.Update(Ingresos);
			return await context.SaveChangesAsync() > 0;

		}

		public async Task<Ingresos?> Buscar(int IngresoId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Ingresos
				.FirstOrDefaultAsync(t => t.IngresoId == IngresoId);
		}

		public async Task<bool> Eliminar(int IngresoId)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Ingresos.Where(t => t.IngresoId == IngresoId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<List<Ingresos>> Listar(Expression<Func<Ingresos, bool>> criterio)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Ingresos.Where(criterio).ToListAsync();

		}

		public async Task<Ingresos?> BuscarConcepto(string Concepto)
		{
			await using var context = await DbContextFactory.CreateDbContextAsync();
			return await context.Ingresos
				.FirstOrDefaultAsync(e => e.Concepto == Concepto);
		}
	}
}
