namespace TaskFlow.Application.Commands.Users.AssignIssues.DTOs
{
	public sealed record AssignIssuesToUserDto(List<Guid> IssueIds);
}
