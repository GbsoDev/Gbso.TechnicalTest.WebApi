using Gbso.TechnicalTest.Model;

namespace Gbso.TechnicalTest.Dto
{
	public class AutoMapperConfiguration : AutoMapper.Profile
	{
		public AutoMapperConfiguration()
		{
			#region User
			CreateMap<User, UserDto>()
				.ForMember(x => x.Id, m => m.MapFrom(y => y.Id))
				.ForMember(x => x.Name, m => m.MapFrom(y => y.Name))
				.ForMember(x => x.Sex, m => m.MapFrom(y => y.Sex))
				.ForMember(x => x.BirthDay, m => m.MapFrom(y => y.BirthDay))
				.ReverseMap();
			#endregion
		}
	}
}
