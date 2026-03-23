using AutoMapper;
using TaskFlow.Application.Finders.Issues.ByUser;
using TaskFlow.Domain.Issues;

namespace TaskFlow.Infrastructure.Persistance.Finders.Issues.ByUser.Profiles
{
	internal class AssignedIssueFmProfile : Profile
	{
		public AssignedIssueFmProfile()
		{
			CreateMap<Issue, AssignedIssueFm>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
		}
	}
}
