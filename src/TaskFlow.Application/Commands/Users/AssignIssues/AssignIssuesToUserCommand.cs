using FluentResults;
using MediatR;

namespace TaskFlow.Application.Commands.Users.AssignIssues
{
	public record AssignIssuesToUserCommand(Guid UserId, IReadOnlyList<Guid> IssueIds) : IRequest<Result>;
}
