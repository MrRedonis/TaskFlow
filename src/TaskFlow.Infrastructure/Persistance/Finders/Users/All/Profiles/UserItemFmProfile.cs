using TaskFlow.Application.Finders.Users.All;

namespace TaskFlow.Infrastructure.Persistance.Finders.Users.All.Profiles
{
	internal class UserItemFmProfile : AutoMapper.Profile
	{
		public UserItemFmProfile()
		{
			CreateMap<Domain.Users.User, UserItemFm>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
		}
	}
}
