using TaskFlow.Domain.Issues;

namespace TaskFlow.Domain.Users
{
	public record IssueAssignment(IssueId IssueId, int Difficulty);
}
