using Gbso.TechnicalTest.Cl;
using Gbso.TechnicalTest.Model;
using Microsoft.EntityFrameworkCore;

namespace Gbso.TechnicalTest.Dal
{
	public class RootContext : DbContext
	{
		public DbSet<User>? Users { get; set; }

		public RootContext(DbContextOptions<RootContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			ModelConfiguration.SetConfiguration(modelBuilder);
		}
	}
}
