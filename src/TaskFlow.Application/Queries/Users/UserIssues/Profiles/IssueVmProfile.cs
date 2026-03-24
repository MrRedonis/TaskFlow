using AutoMapper;
using TaskFlow.Application.Finders.Issues.ByUser;

namespace TaskFlow.Application.Queries.Users.UserIssues.Profiles
{
	internal class IssueVmProfile : Profile
	{
		public IssueVmProfile()
		{
			CreateMap<AssignedIssueFm, ViewModels.IssueVm>();
		}
	}
}
