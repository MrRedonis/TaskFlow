using TaskFlow.Domain.Issues;
using TaskFlow.Domain.Users;

namespace TaskFlow.Infrastructure.Persistance.Data
{
	internal static class MockData
	{
		public static List<User> Users { get; } = new()
	{
		new User(new UserId(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")), "Jan", "Kowalski", "jan.kowalski@example.com", UserType.Developer),
		new User(new UserId(Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")), "Anna", "Nowak", "anna.nowak@example.com", UserType.DevOpsAdministrator),
		new User(new UserId(Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc")), "Piotr", "Zieliński", "piotr.zielinski@example.com", UserType.Developer),
		new User(new UserId(Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd")), "Katarzyna", "Wiśniewska", "k.wisniewska@example.com", UserType.DevOpsAdministrator),
		new User(new UserId(Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee")), "Marek", "Lewandowski", "marek.lew@example.com", UserType.Developer),
		new User(new UserId(Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff")), "Julia", "Mazur", "julia.mazur@example.com", UserType.DevOpsAdministrator),
		new User(new UserId(Guid.Parse("99999999-9999-9999-9999-999999999999")), "Tomasz", "Wójcik", "tomasz.wojcik@example.com", UserType.Developer)
	};

		public static List<Issue> Issues { get; } = GenerateIssues();

		private static List<Issue> GenerateIssues()
		{
			return new List<Issue>
		{
            // IMPLEMENTATION (8)
            new ImplementationIssue(IssueId.New(), "Implement user login", IssueDifficulty.Four, "Add JWT authentication"),
			new ImplementationIssue(IssueId.New(), "Create dashboard UI", IssueDifficulty.One, "Basic layout and widgets"),
			new ImplementationIssue(IssueId.New(), "Refactor payment module", IssueDifficulty.Five, "Split into smaller services"),
			new ImplementationIssue(IssueId.New(), "Optimize SQL queries", IssueDifficulty.Three, "Rewrite slow queries"),
			new ImplementationIssue(IssueId.New(), "Add dark mode", IssueDifficulty.Two, "UI theme switcher"),
			new ImplementationIssue(IssueId.New(), "Implement notifications", IssueDifficulty.Four, "Email + push notifications"),
			new ImplementationIssue(IssueId.New(), "Fix caching layer", IssueDifficulty.Three, "Redis invalidation bug"),
			new ImplementationIssue(IssueId.New(), "Rewrite auth middleware", IssueDifficulty.Five, "Security improvements"),

            // MAINTENANCE (6)
            new MaintenanceIssue(IssueId.New(), "Update SSL certificates", IssueDifficulty.Three, new DateOnly(2026,4,10), "Auth, API Gateway", "srv01, srv02"),
			new MaintenanceIssue(IssueId.New(), "Clean up old logs", IssueDifficulty.Two, new DateOnly(2026,4,5), "Logging Service", "srv-log-01"),
			new MaintenanceIssue(IssueId.New(), "Rotate backups", IssueDifficulty.One, new DateOnly(2026,4,7), "Backup Service", "backup01"),
			new MaintenanceIssue(IssueId.New(), "Restart failing pods", IssueDifficulty.Four, new DateOnly(2026,4,3), "Kubernetes", "k8s-node-02"),
			new MaintenanceIssue(IssueId.New(), "Check disk usage", IssueDifficulty.Two, new DateOnly(2026,4,2), "Monitoring", "srv-monitor-01"),
			new MaintenanceIssue(IssueId.New(), "Update firewall rules", IssueDifficulty.Five, new DateOnly(2026,4,12), "Security", "fw01"),

            // DEPLOYMENT (6)
            new DeploymentIssue(IssueId.New(), "Deploy new API version", IssueDifficulty.Three, new DateOnly(2026,4,12), "Backend services"),
			new DeploymentIssue(IssueId.New(), "Roll out hotfix", IssueDifficulty.Four, new DateOnly(2026,4,3), "Critical bugfix"),
			new DeploymentIssue(IssueId.New(), "Deploy frontend build", IssueDifficulty.Two, new DateOnly(2026,4,8), "SPA build"),
			new DeploymentIssue(IssueId.New(), "Migrate database schema", IssueDifficulty.Five, new DateOnly(2026,4,15), "DB migration"),
			new DeploymentIssue(IssueId.New(), "Deploy monitoring update", IssueDifficulty.One, new DateOnly(2026,4,6), "Grafana + Prometheus"),
			new DeploymentIssue(IssueId.New(), "Deploy new auth service", IssueDifficulty.Four, new DateOnly(2026,4,11), "Auth microservice")
		};
		}
	}
}
