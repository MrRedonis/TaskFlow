namespace TaskFlow.Application.Queries.Users.User.ViewModels
{
	public record UserVm(
		Guid Id,
		string FirstName,
		string LastName,
		string Email,
		string Type
	);
}
