using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Gbso.TechnicalTest.Cl.Exception
{
	public class ValidateException : System.Exception
	{
		public ValidateException()
		{
		}

		public ValidateException(string? message) : base(message)
		{
		}

		public ValidateException(string? message, System.Exception? innerException) : base(message, innerException)
		{
		}

		public ValidateException(string? message, params ValidationResult[] validations) : base(message)
		{
		}

		protected ValidateException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}