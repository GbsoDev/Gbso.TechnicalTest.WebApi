using Gbso.TechnicalTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbso.TechnicalTest.Cl.BllService
{
	public interface IUserService
	{
		User GeyById(int id);
		User[] List();
		User Register(User user);
		User Update(User user);
		void Delete(int id);
	}
}
