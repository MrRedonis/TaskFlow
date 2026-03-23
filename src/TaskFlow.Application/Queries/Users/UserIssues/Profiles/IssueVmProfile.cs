using AutoMapper;
using TaskFlow.Domain.Issues;

namespace TaskFlow.Application.Queries.Users.UserIssues.Profiles
{
	internal class IssueVmProfile : Profile
	{
		public IssueVmProfile()
		{
			CreateMap<Issue, ViewModels.IssueVm>();
		}
	}
}
