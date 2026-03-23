namespace TaskFlow.Application.Finders.Issues.ByUser
{ 
	public record AssignedIssueFm(
		Guid Id,
		string Title,
		int Difficulty,
		string Type
	);
}
