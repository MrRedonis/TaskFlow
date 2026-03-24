using MediatR;
using TaskFlow.Application.Queries.Issues.Issue.ViewModels;

namespace TaskFlow.Application.Queries.Issues.Issue
{
	public record IssueQuery(Guid IssueId) : IRequest<IssueDetailVm?>
	{
	}
}
