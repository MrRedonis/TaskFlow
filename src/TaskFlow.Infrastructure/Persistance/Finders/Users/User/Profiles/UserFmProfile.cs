using TaskFlow.Application.Finders.Users.User;

namespace TaskFlow.Infrastructure.Persistance.Finders.Users.User.Profiles
{
	internal class UserFmProfile : AutoMapper.Profile
	{
		public UserFmProfile()
		{
			CreateMap<Domain.Users.User, UserFm>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
		}
	}
}
