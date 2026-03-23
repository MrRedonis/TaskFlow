namespace TaskFlow.Application.Queries.Issues.AvailableIssues.ViewModels
{
	public record AvailableIssueVm(
		Guid Id,
		string Title,
		int Difficulty,
		string Type
	);
}
