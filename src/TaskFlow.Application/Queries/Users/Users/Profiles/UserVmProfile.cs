using AutoMapper;
using TaskFlow.Application.Finders.Users.All;

namespace TaskFlow.Application.Queries.Users.Users.Profiles
{
	internal class UserVmProfile : Profile
	{
		public UserVmProfile()
		{
			CreateMap<UserItemFm, ViewModels.UserItemVm>();
		}
	}
}
