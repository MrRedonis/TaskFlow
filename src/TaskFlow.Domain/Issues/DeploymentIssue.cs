using TaskFlow.Domain.Exceptions;

namespace TaskFlow.Domain.Issues
{
	public class DeploymentIssue : Issue
	{
		public override IssueType Type => IssueType.Deployment;
		public DateOnly DueDate { get; private set; }
		public string Scope { get; private set; }

		public DeploymentIssue(IssueId id, string title, IssueDifficulty difficulty, DateOnly dueDate, string scope,
			IssueStatus status = IssueStatus.Pending) : base(id, title, difficulty, status)
		{
			if (string.IsNullOrWhiteSpace(scope))
			{
				throw new DomainException("Scope cannot be empty");
			}

			if (scope.Length > 400)
			{
				throw new DomainException("Scope cannot exceed 400 characters.");
			}

			DueDate = dueDate;
			Scope = scope;
		}
	}
}
