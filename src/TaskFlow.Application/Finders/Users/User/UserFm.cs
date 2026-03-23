namespace TaskFlow.Application.Finders.Users.User
{
	public record UserFm(
		Guid Id,
		string FirstName,
		string LastName,
		string Email,
		string Type
	);
}
