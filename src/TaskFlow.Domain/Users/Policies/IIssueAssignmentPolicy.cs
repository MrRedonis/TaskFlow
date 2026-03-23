using TaskFlow.Domain.Issues;

namespace TaskFlow.Domain.Users.Policies
{
	public interface IIssueAssignmentPolicy
	{
		public void Validate(User user, IEnumerable<Issue> newIssues);
	}
}
