using TaskFlow.Application.Common.Finders;

namespace TaskFlow.Application.Finders.Users.User
{
	public interface IUserFinder : IFinder<GetUserParam, UserFm>
	{
	}
}
