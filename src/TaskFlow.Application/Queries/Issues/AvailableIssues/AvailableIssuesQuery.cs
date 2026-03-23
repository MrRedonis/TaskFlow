using MediatR;
using TaskFlow.Application.Common.Pagination;
using TaskFlow.Application.Queries.Issues.AvailableIssues.ViewModels;

namespace TaskFlow.Application.Queries.Issues.AvailableIssues
{
	public class AvailableIssuesQuery : IRequest<PagedResult<AvailableIssueVm>>
	{
		public int Page { get; set; } = 1;
		public int PageSize { get; set; } = 10;
	}
}
