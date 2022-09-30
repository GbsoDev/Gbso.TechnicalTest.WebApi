using FluentValidation;
using Gbso.TechnicalTest.Bll.ValidationRules;
using Gbso.TechnicalTest.Cl.BllService;
using Gbso.TechnicalTest.Cl.DalService;
using Gbso.TechnicalTest.Cl.Exception;
using Gbso.TechnicalTest.Model;

namespace Gbso.TechnicalTest.Bll
{
	public sealed class UserService : BaseService, IUserService
	{
		private IUserDal UserDal => _userDal.Value;
		private readonly Lazy<IUserDal> _userDal;
		private readonly IValidator<User> UserValidator;

		public UserService(IServiceProvider serviceProvider, Lazy<IUserDal> userDal, IValidator<User> userValidator) : base(serviceProvider)
		{
			_userDal = userDal;
			UserValidator = userValidator;
		}

		public User Register(User user)
		{
			var validation = UserValidator.Validate(user, n => n.IncludeAllRuleSets());
			if (!validation.IsValid)
				throw new ValidateException(BllValidationResx.User_RegisterVr, validation);
			UserDal.Register(user);
			return user;
		}

		public User GeyById(int id)
		{
			var userResult = UserDal.GetById(id);
			if (userResult == null)
				throw new ValidateException(BllValidationResx.User_DataNotFound);
			return userResult;
		}

		public User[] List()
		{
			var usersResult = UserDal.Get();
			if (!usersResult.Any())
				throw new ValidateException(BllValidationResx.User_DataNotFound);
			return usersResult;
		}

		public User Update(User user)
		{
			var validation = UserValidator.Validate(user, n => n.IncludeRuleSets(VrRuleSets.UPDATE));
			if (!validation.IsValid)
			{
				throw new ValidateException(BllValidationResx.User_DataNotFound, validation);
			}
			var userResult = UserDal.Update(user);
			if (userResult == null)
			{
				throw new BllHandledException(BllHandledExceptionResx.Update_NotFound);
			}
			return userResult;
		}

		public void Delete(int id)
		{
			var isValid = id > 0;
			if (!isValid)
			{
				throw new ValidateException(BllValidationResx.DeleteVr);
			}
			UserDal.Remove(id);
		}
	}
}
