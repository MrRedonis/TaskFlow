namespace TaskFlow.Application.Finders.Users.All
{
	public record UserItemFm(
		Guid Id,
		string FirstName,
		string LastName,
		string Email
	);
}
