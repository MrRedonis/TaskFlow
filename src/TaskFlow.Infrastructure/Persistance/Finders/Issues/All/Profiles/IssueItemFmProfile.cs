using TaskFlow.Application.Finders.Issues.All;
using TaskFlow.Domain.Issues;

namespace TaskFlow.Infrastructure.Persistance.Finders.Issues.All.Profiles
{
	internal class IssueItemFmProfile : AutoMapper.Profile
	{
		public IssueItemFmProfile()
		{
			CreateMap<Issue, IssueItemFm>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
		}
	}
}
