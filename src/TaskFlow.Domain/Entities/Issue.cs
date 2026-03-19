using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
	public abstract class Issue
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public IssueDifficulty Difficulty { get; set; }
		public IssueType Type { get; set; }
	}
}
