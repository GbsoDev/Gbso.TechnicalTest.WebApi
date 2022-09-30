using FluentValidation;
using Gbso.TechnicalTest.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Gbso.TechnicalTest.Bll.ValidationRules
{
	public static class BllValidationLayer
	{
		public static IServiceCollection AddBllValidationRulesLayer(this IServiceCollection services)
		{
			services.AddSingleton<IValidator<User>, UserVr>();
			return services;
		}
	}
}
