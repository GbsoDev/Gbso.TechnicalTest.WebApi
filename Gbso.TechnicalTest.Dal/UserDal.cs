using Gbso.TechnicalTest.Cl.DalService;
using Gbso.TechnicalTest.Model;

namespace Gbso.TechnicalTest.Dal
{
	public sealed class UserDal : BaseDataAccesLayer<User, int?>, IUserDal
	{	
		public UserDal(IServiceProvider serviceProvider) : base(serviceProvider)
		{

		}
	}
}