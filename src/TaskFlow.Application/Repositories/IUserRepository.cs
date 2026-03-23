using TaskFlow.Domain.Users;

namespace TaskFlow.Application.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
		Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);
		Task UpdateAsync(User user, CancellationToken cancellationToken = default);
	}
}
