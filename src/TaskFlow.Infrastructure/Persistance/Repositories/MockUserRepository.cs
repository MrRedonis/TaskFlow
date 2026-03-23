using TaskFlow.Application.Repositories;
using TaskFlow.Domain.Users;
using TaskFlow.Infrastructure.Persistance.Data;

namespace TaskFlow.Infrastructure.Persistance.Repositories
{
	internal class MockUserRepository : IUserRepository
	{
		public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return MockData.Users;
		}

		public async Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default)
		{
			return MockData.Users.Find(x => x.Id == id);
		}

		public Task UpdateAsync(User user, CancellationToken cancellationToken = default)
		{
			return Task.CompletedTask;
		}
	}
}
