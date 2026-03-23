using TaskFlow.Application.Common.Finders;

namespace TaskFlow.Application.Finders.Users.All
{
	public interface IUsersFinder : ICollectionFinder<GetUsersParam, UserItemFm>
	{
	}
}
