using AutoMapper;
using TaskFlow.Application.Finders.Issues.ById;
using TaskFlow.Application.Queries.Issues.Issue.ViewModels;

namespace TaskFlow.Application.Queries.Issues.Issue.Profiles
{
	internal class IssueDetailVmProfile : Profile
	{
		public IssueDetailVmProfile()
		{
			CreateMap<IssueDetailFm, IssueDetailVm>();
		}
	}
}
