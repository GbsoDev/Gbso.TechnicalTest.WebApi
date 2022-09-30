using Gbso.TechnicalTest.Model;
using Microsoft.EntityFrameworkCore;

namespace Gbso.TechnicalTest.Dal
{
	internal static class ModelConfiguration
	{
		internal static void SetConfiguration(ModelBuilder modelBuilder)
		{
			#region userEntity
			var userEntity = modelBuilder.Entity<User>();
			userEntity.ToTable("Users");
			userEntity.HasKey(x => x.Id);
			userEntity.Property(x => x.Name).IsRequired().HasMaxLength(100);
			userEntity.Property(x => x.Sex).IsRequired().HasColumnType("char").HasMaxLength(1);
			userEntity.Property(x => x.BirthDay).IsRequired();
			#endregion
		}
	}
}
