using AutoMapper;
using TaskFlow.Application.Finders.Issues.All;
using TaskFlow.Application.Queries.Issues.AvailableIssues.ViewModels;

namespace TaskFlow.Application.Queries.Issues.AvailableIssues.Profiles
{
	internal class AvailableIssueVmProfile : Profile
	{
		public AvailableIssueVmProfile()
		{
			CreateMap<IssueItemFm, AvailableIssueVm>();
		}
	}
}
