using TaskFlow.Domain.Exceptions;
using TaskFlow.Domain.Issues;

namespace TaskFlow.Domain.Users.Policies
{
	public class DeveloperIssueAssignmentPolicy : BaseIssueAssignmentPolicy
	{
		protected override void ValidateRoleSpecificRules(User user, IEnumerable<Issue> newIssues)
		{
			if (newIssues.Any(i => i.Type != IssueType.Implementation))
				throw new DomainException("Developer can only receive Implementation tasks.");
		}
	}
}
