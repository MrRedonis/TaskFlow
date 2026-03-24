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
            new ImplementationIssue(NewIssueId("8f4526f7-f85d-47a7-8ab2-9e5fabe19348"), "Implement user login", IssueDifficulty.Five, "Add JWT authentication"),
			new ImplementationIssue(NewIssueId("1cf4c968-ea6a-48f2-aac7-e62496ec44b7"), "Create dashboard UI", IssueDifficulty.Four, "Basic layout and widgets"),
			new ImplementationIssue(NewIssueId("329bf437-b4ba-43af-b8d5-db54c81b5096"), "Refactor payment module", IssueDifficulty.Three, "Split into smaller services"),
			new ImplementationIssue(NewIssueId("220ffec1-85d9-4fea-be3d-709e5ae93d44"), "Optimize SQL queries", IssueDifficulty.Three, "Rewrite slow queries"),
			new ImplementationIssue(NewIssueId("7acfee96-f380-4fc0-990b-ed0198f34de2"), "Add dark mode", IssueDifficulty.Two, "UI theme switcher"),
			new ImplementationIssue(NewIssueId("75a4f286-34d6-462a-bd50-46688fc6eab4"), "Implement notifications", IssueDifficulty.Two, "Email + push notifications"),
			new ImplementationIssue(NewIssueId("935d0f71-ca19-4074-9bcb-7ee949fb7118"), "Fix caching layer", IssueDifficulty.One, "Redis invalidation bug"),
			new ImplementationIssue(NewIssueId("bbc1392e-7149-40ae-abd7-931798f8ab79"), "Rewrite auth middleware", IssueDifficulty.One, "Security improvements"),

            // MAINTENANCE (6)
            new MaintenanceIssue(NewIssueId("f70152c8-3f2f-4284-9963-8c14eed48bfe"), "Update SSL certificates", IssueDifficulty.Three, new DateOnly(2026,4,10), "Auth, API Gateway", "srv01, srv02"),
			new MaintenanceIssue(NewIssueId("f94cb297-0a22-4acf-98d9-69147ea827ea"), "Clean up old logs", IssueDifficulty.Two, new DateOnly(2026,4,5), "Logging Service", "srv-log-01"),
			new MaintenanceIssue(NewIssueId("6793de20-0d82-4444-8d10-6c9697afa52f"), "Rotate backups", IssueDifficulty.One, new DateOnly(2026,4,7), "Backup Service", "backup01"),
			new MaintenanceIssue(NewIssueId("d29cbd88-e10f-4f20-be1a-662495ddc986"), "Restart failing pods", IssueDifficulty.Four, new DateOnly(2026,4,3), "Kubernetes", "k8s-node-02"),
			new MaintenanceIssue(NewIssueId("5f697d0a-7068-497c-ace4-dead4a4302f9"), "Check disk usage", IssueDifficulty.Two, new DateOnly(2026,4,2), "Monitoring", "srv-monitor-01"),
			new MaintenanceIssue(NewIssueId("8a40b299-0694-4cf6-a4bf-74368bba7041"), "Update firewall rules", IssueDifficulty.Five, new DateOnly(2026,4,12), "Security", "fw01"),

            // DEPLOYMENT (6)
            new DeploymentIssue(NewIssueId("5c5e5f0c-57cb-49ef-ba65-5bda0651c8cf"), "Deploy new API version", IssueDifficulty.Three, new DateOnly(2026,4,12), "Backend services"),
			new DeploymentIssue(NewIssueId("3cd7cd47-f6ef-4584-8b83-de744be0abd6"), "Roll out hotfix", IssueDifficulty.Four, new DateOnly(2026,4,3), "Critical bugfix"),
			new DeploymentIssue(NewIssueId("e954c9ed-583b-4a8f-abee-27e3b8087787"), "Deploy frontend build", IssueDifficulty.Two, new DateOnly(2026,4,8), "SPA build"),
			new DeploymentIssue(NewIssueId("0d28f2e4-fe2c-4333-b4d2-f9d11c2c44fb"), "Migrate database schema", IssueDifficulty.Five, new DateOnly(2026,4,15), "DB migration"),
			new DeploymentIssue(NewIssueId("cb83f8f1-0fc7-4499-a0ab-8b13272a2805"), "Deploy monitoring update", IssueDifficulty.One, new DateOnly(2026,4,6), "Grafana + Prometheus"),
			new DeploymentIssue(NewIssueId("e923a0f4-6972-4902-9fb9-91d20105feeb"), "Deploy new auth service", IssueDifficulty.Four, new DateOnly(2026,4,11), "Auth microservice")
		};
		}

		private static IssueId NewIssueId(string guid) => new IssueId(new Guid(guid));
	}
}
