using FluentValidation;
using Gbso.TechnicalTest.Cl;

namespace Gbso.TechnicalTest.Dto.ValidationRules
{
	public class UserDtoVr : AbstractValidator<UserDto>
	{
		public UserDtoVr()
		{
			RuleFor(c => c.Name)
				.NotNull().WithMessage(x => string.Format(CommonResx.VrPropertyNull, nameof(x.Name)))
				.NotEmpty().WithMessage(x => string.Format(CommonResx.VrPropertyNull, nameof(x.Name)))
				.MaximumLength(100);
			RuleFor(c => c.Sex)
				.NotNull().WithMessage(x => string.Format(CommonResx.VrPropertyNull, nameof(x.Sex)))
				.NotEmpty().WithMessage(x => string.Format(CommonResx.VrPropertyNull, nameof(x.Sex)));
			RuleFor(c => c.BirthDay)
				.NotNull().WithMessage(x => string.Format(CommonResx.VrPropertyNull, nameof(x.BirthDay)))
				.NotEmpty().WithMessage(x => string.Format(CommonResx.VrPropertyNull, nameof(x.BirthDay)));
		}
	}
}
