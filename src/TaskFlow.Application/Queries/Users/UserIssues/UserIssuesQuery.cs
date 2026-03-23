using MediatR;
using TaskFlow.Application.Common.Pagination;
using TaskFlow.Application.Queries.Users.UserIssues.ViewModels;

namespace TaskFlow.Application.Queries.Users.UserIssues
{
	public sealed record UserIssuesQuery(Guid UserId, int Page, int PageSize) : IRequest<PagedResult<IssueVm>>;
}
