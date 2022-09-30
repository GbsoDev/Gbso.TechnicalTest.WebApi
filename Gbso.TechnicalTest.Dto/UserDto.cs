using Gbso.TechnicalTest.Model;

namespace Gbso.TechnicalTest.Dto
{
	public sealed class UserDto
	{
		public int? Id { get; set; }
		public string? Name { get; set; }
		public Sex? Sex { get; set; }
		public DateTime? BirthDay { get; set; }
	}
}
