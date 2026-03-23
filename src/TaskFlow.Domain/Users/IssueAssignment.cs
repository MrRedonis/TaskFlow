using TaskFlow.Domain.Issues;

namespace TaskFlow.Domain.Users
{
	public class IssueAssignment
	{
		public IssueId IssueId { get; }
		public int Difficulty { get; }

		public IssueAssignment(Issue issue)
		{
			IssueId = issue.Id;
			Difficulty = (int)issue.Difficulty;
		}
	}
}
