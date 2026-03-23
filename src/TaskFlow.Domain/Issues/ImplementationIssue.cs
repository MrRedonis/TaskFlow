using TaskFlow.Domain.Exceptions;

namespace TaskFlow.Domain.Issues
{
	public class ImplementationIssue : Issue
	{
		public override IssueType Type => IssueType.Implementation;
		public string Content { get; private set; }

		public ImplementationIssue(IssueId id, string title, IssueDifficulty difficulty, string content,
			IssueStatus status = IssueStatus.Pending) : base(id, title, difficulty, status)
		{
			if (string.IsNullOrWhiteSpace(content))
			{
				throw new DomainException("Content cannot be empty");
			}

			if (content.Length > 1000)
			{
				throw new DomainException("Content cannot exceed 1000 characters.");
			}

			Content = content;
		}
	}
}
