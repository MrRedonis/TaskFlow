namespace TaskFlow.Application.Finders.Issues.ById
{
	public record IssueDetailFm(
		Guid Id,
		string Title,
		int Difficulty,
		string Type,
		string Status,
		Dictionary<string, object?> CustomFields
	);
}
