using AutoMapper;
using TaskFlow.Application.Finders.Issues.ById;
using TaskFlow.Domain.Issues;

namespace TaskFlow.Infrastructure.Persistance.Finders.Issues.ById.Profiles
{
	internal class IssueDetailFmProfile : Profile
	{
		public IssueDetailFmProfile()
		{
			CreateMap<Issue, IssueDetailFm>()
				.ConvertUsing((issue, _, _) =>
				{
					var custom = new Dictionary<string, object?>();

					switch (issue)
					{
						case ImplementationIssue impl:
							custom["content"] = impl.Content;
							break;

						case MaintenanceIssue maint:
							custom["dueDate"] = maint.DueDate;
							custom["services"] = maint.Services;
							custom["servers"] = maint.Servers;
							break;

						case DeploymentIssue dep:
							custom["dueDate"] = dep.DueDate;
							custom["scope"] = dep.Scope;
							break;
					}

					return new IssueDetailFm(
						issue.Id.Value,
						issue.Title,
						(int)issue.Difficulty,
						issue.Type.ToString(),
						issue.Status.ToString(),
						custom
					);
				});
		}
	}
}
