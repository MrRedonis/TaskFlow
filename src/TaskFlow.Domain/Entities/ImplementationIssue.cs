using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
	public class ImplementationIssue : Issue
	{
		public string Content { get; set; }

		public ImplementationIssue()
		{
			Type = IssueType.Implementation;
		}
	}
}
