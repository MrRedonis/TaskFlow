using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
		Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
	}
}
