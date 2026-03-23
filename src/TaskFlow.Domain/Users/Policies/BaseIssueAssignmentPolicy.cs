using TaskFlow.Domain.Exceptions;
using TaskFlow.Domain.Issues;

namespace TaskFlow.Domain.Users.Policies
{
	public abstract class BaseIssueAssignmentPolicy : IIssueAssignmentPolicy
	{
		public void Validate(User user, IEnumerable<Issue> newIssues)
		{
			var issues = newIssues.ToList();

			ValidateTaskReadyToAssign(issues);
			ValidateTaskCount(user, issues);
			ValidateDifficultyDistribution(user, issues);

			ValidateRoleSpecificRules(user, issues);
		}

		protected abstract void ValidateRoleSpecificRules(User user, IEnumerable<Issue> newIssues);

		protected void ValidateTaskReadyToAssign(IEnumerable<Issue> newIssues)
		{
			if (newIssues.Any(i => i.IsAssigned))
			{
				throw new DomainException("Some issues are already assigned");
			}
		}

		protected void ValidateTaskCount(User user, IEnumerable<Issue> newIssues)
		{
			var total = user.Assignments.Count + newIssues.Count();

			if (total < 5 || total > 11)
			{
				throw new DomainException("User must have between 5 and 11 issues.");
			}
		}

		protected void ValidateDifficultyDistribution(User user, IEnumerable<Issue> newIssues)
		{
			var existing = user.Assignments.Select(a => a.Difficulty);
			var incoming = newIssues.Select(i => (int)i.Difficulty);

			var all = existing.Concat(incoming).ToList();
			var total = all.Count;

			if (total == 0)
				return;

			var hardRatio = (double)all.Count(d => d >= 4) / total;
			var easyRatio = (double)all.Count(d => d <= 2) / total;

			if (hardRatio < 0.10 || hardRatio > 0.30)
				throw new DomainException("User must have 10–30% difficult issues.");

			if (easyRatio > 0.50)
				throw new DomainException("User cannot have more than 50% easy issues.");
		}
	}
}
