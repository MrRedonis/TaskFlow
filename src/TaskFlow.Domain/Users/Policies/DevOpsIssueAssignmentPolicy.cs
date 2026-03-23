using TaskFlow.Domain.Exceptions;
using TaskFlow.Domain.Issues;

namespace TaskFlow.Domain.Users.Policies
{
	public class DevOpsIssueAssignmentPolicy : BaseIssueAssignmentPolicy
	{
		protected override void ValidateRoleSpecificRules(User user, IEnumerable<Issue> newIssues)
		{
			if (newIssues.Any(i => 
				    i.Type != IssueType.Implementation &&
				    i.Type != IssueType.Deployment &&
					i.Type != IssueType.Maintenance))
				throw new DomainException("DevOps / Administrator can only receive Implementation / Deployment / Maintenance tasks.");
		}
	}
}
