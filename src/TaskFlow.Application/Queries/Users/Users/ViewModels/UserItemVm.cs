namespace TaskFlow.Application.Queries.Users.Users.ViewModels
{
	public record UserItemVm(
		Guid Id,
		string FirstName,
		string LastName,
		string Email
	);
}
