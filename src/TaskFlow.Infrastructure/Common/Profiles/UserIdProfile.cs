using AutoMapper;
using TaskFlow.Domain.Users;

namespace TaskFlow.Infrastructure.Common.Profiles
{
	internal class UserIdProfile : Profile
	{
		public UserIdProfile()
		{
			CreateMap<UserId, Guid>()
				.ConvertUsing(src => src.Value);
		}
	}
}
