using AutoMapper;
using TaskFlow.Application.Finders.Users.User;

namespace TaskFlow.Application.Queries.Users.User.Profiles
{
	internal class UserVmProfile : Profile
	{
		public UserVmProfile()
		{
			CreateMap<UserFm, ViewModels.UserVm>();
		}
	}
}
