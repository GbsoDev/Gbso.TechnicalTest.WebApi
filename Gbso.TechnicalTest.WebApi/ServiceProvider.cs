using Gbso.TechnicalTest.Bll;
using Gbso.TechnicalTest.Cl.BllService;
using Gbso.TechnicalTest.Cl.DalService;
using Gbso.TechnicalTest.Dal;

namespace Gbso.TechnicalTest.WebApi
{
	public static class ServiceProvider
	{
		public static IServiceCollection AddServicesLayer(this IServiceCollection services)
		{
			services.AddScoped<IUserService, UserService>()
					.AddScoped(serviceProvider => new Lazy<IUserService>(() => serviceProvider.GetRequiredService<IUserService>()));
			return services;
		}

		public static IServiceCollection AddDataLayer(this IServiceCollection services)
		{
			services.AddScoped<IUserDal, UserDal>()
					.AddScoped(serviceProvider => new Lazy<IUserDal>(() => serviceProvider.GetRequiredService<IUserDal>()));

			return services;
		}
	}
}
