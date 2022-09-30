using Gbso.TechnicalTest.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gbso.TechnicalTest.WebApi
{
	public class DbContextFactory : IDesignTimeDbContextFactory<RootContext>
	{
		/// <summary>
		/// Con la consola del administrador de paquetes, podremos ejecutar Add-Migration "Drop-Database ,Get-DbContext ,Scaffold-DbContext
		///Script-Migrations ,Update-Database", Recibe variables de entorno indicando en optionsbuilder Environment.GetEnvironmentVariable(""),
		///o solo pasar la cadena de conexion local estrutura ->"Server=localhost;Port=5432;Database=namedatabase;User Id=user;Password=password;"
		/// Get-Help about_EntityFrameworkCore -> comando para visualizar las ayudas
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public RootContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<RootContext>();
#if !DEBUG
			var rooConnectionString = Utils.BuildConfiguration().GetConnectionString(Utils.CONNECTION_ROOT_NAME);
#else
			var rooConnectionString = Utils.BuildConfiguration().GetConnectionString(Utils.CONNECTION_MIGRATIONS_NAME);
#endif
			optionsBuilder.UseNpgsql(rooConnectionString);
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
			return new RootContext(optionsBuilder.Options);
		}
	}
}

