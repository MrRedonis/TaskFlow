using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
	public class DeploymentIssue : Issue
	{
		public DateOnly DueDate { get; set; }
		public string Scope { get; set; }

		public DeploymentIssue()
		{
			Type = IssueType.Deployment;
		}
	}
}
