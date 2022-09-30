using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Gbso.TechnicalTest.Dto.ValidationRules
{
	public static class DtoValidationRulesLayer
	{
		public static IServiceCollection AddDtoValidationRulesLayer(this IServiceCollection services)
		{
			services.AddSingleton<IValidator<UserDto>, UserDtoVr>();
			return services;
		}
	}
}
