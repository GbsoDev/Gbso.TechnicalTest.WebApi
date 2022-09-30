using FluentValidation;
using Gbso.TechnicalTest.Cl;
using Gbso.TechnicalTest.Model;

namespace Gbso.TechnicalTest.Bll.ValidationRules
{
	public class UserVr : AbstractValidator<User>
	{
		public UserVr()
		{
			RuleSet(VrRuleSets.UPDATE, () =>
			{
				RuleFor(x => x.Id)
					.NotEmpty()
					.Must(y => y > 0)
					.WithMessage(x => string.Format(CommonResx.VrPropertyEmpty, nameof(x.Id)));
			});

			RuleFor(c => c.Name)
				.NotNull().WithMessage(x => string.Format(CommonResx.VrPropertyNull, nameof(x.Name)))
				.NotEmpty().WithMessage(x => string.Format(CommonResx.VrPropertyEmpty, nameof(x.Name)));
			RuleFor(c => c.Sex)
				.NotNull().WithMessage(x => string.Format(CommonResx.VrPropertyNull, nameof(x.Sex)))
				.NotEmpty().WithMessage(x => string.Format(CommonResx.VrPropertyEmpty, nameof(x.Sex)));
			RuleFor(c => c.BirthDay)
				.NotNull().WithMessage(x => string.Format(CommonResx.VrPropertyNull, nameof(x.BirthDay)))
				.NotEmpty().WithMessage(x => string.Format(CommonResx.VrPropertyEmpty, nameof(x.BirthDay)));
		}

	}
}
