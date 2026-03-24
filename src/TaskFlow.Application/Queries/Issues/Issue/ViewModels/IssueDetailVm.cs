namespace TaskFlow.Application.Queries.Issues.Issue.ViewModels
{
	public record IssueDetailVm(
		Guid Id,
		string Title,
		int Difficulty,
		string Type,
		string Status,
		Dictionary<string, object?> CustomFields
	);
}
