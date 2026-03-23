namespace TaskFlow.Application.Finders.Issues.All
{
	public record IssueItemFm(
		Guid Id,
		string Title,
		int Difficulty,
		string Type
	);
}
