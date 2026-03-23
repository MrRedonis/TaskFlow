using AutoMapper;
using TaskFlow.Domain.Issues;

namespace TaskFlow.Infrastructure.Common.Profiles
{
	internal class IssueIdProfile : Profile
	{
		public IssueIdProfile()
		{
			CreateMap<IssueId, Guid>()
				.ConvertUsing(src => src.Value);
		}
	}
}
