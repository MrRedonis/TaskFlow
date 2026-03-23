using TaskFlow.Domain.Users;

namespace TaskFlow.Application.Finders.Users.User
{
	public class GetUserParam(UserId userId)
	{
		public UserId UserId { get; set; } = userId;
	}
}
