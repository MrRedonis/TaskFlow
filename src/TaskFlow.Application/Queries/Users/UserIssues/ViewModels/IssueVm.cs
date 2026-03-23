namespace TaskFlow.Application.Queries.Users.UserIssues.ViewModels
{
	public record IssueVm(
		Guid Id,
		string Title,
		int Difficulty,
		string Type
	);
}
