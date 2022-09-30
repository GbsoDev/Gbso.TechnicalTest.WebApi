using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gbso.TechnicalTest.Cl.Exception
{
	public sealed class BllHandledException : System.Exception
	{
		public BllHandledException()
		{
		}

		public BllHandledException(string? message) : base(message)
		{
		}

		public BllHandledException(string? message, System.Exception? innerException) : base(message, innerException)
		{
		}
	}
}
