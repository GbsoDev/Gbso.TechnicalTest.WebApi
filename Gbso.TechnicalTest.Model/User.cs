namespace Gbso.TechnicalTest.Model
{
	public class User : IModel<int?>
	{
		public int? Id { get; set; }
		public string? Name { get; set; }
		public Sex? Sex { get; set; }
		public DateTime? BirthDay { get; set; }
	}
}
