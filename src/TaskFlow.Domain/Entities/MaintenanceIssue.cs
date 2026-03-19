using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
	public class MaintenanceIssue : Issue
	{
		public DateOnly DueDate { get; set; }
		public string Services { get; set; }
		public string Servers { get; set; }

		public MaintenanceIssue()
		{
			Type = IssueType.Maintenance;
		}
	}
}
