using TaskFlow.Domain.Exceptions;

namespace TaskFlow.Domain.Issues
{
	public class MaintenanceIssue : Issue
	{
		public override IssueType Type => IssueType.Maintenance;
		public DateOnly DueDate { get; private set; }
		public string Services { get; private set; }
		public string Servers { get; private set; }

		public MaintenanceIssue(IssueId id, string title, IssueDifficulty difficulty, DateOnly dueDate, string services,
			string servers, IssueStatus status = IssueStatus.Pending) : base(id, title, difficulty, status)
		{
			if (string.IsNullOrWhiteSpace(services))
			{
				throw new DomainException("Services cannot be empty");
			}

			if (string.IsNullOrWhiteSpace(servers))
			{
				throw new DomainException("Servers cannot be empty");
			}

			if (services.Length > 400)
			{
				throw new DomainException("Services cannot exceed 400 characters.");
			}

			if (servers.Length > 400)
			{
				throw new DomainException("Servers cannot exceed 400 characters.");
			}

			DueDate = dueDate;
			Services = services;
			Servers = servers;
		}
	}
}
