using TaskFlow.Application.Repositories;
using TaskFlow.Domain.Users;
using TaskFlow.Infrastructure.Persistance.Db;

namespace TaskFlow.Infrastructure.Persistance.Repositories
{
	internal class MockUserRepository : IUserRepository
	{
		private readonly InMemoryDatabase _database;

		public MockUserRepository(InMemoryDatabase database)
		{
			_database = database;
		}

		public async Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default)
		{
			return _database.Users.Find(x => x.Id == id);
		}

		public Task UpdateAsync(User user, CancellationToken cancellationToken = default)
		{
			var index = _database.Users.FindIndex(x => x.Id == user.Id);
			if (index >= 0)
			{
				_database.Users[index] = user;
				_database.Track(user);
			}

			return Task.CompletedTask;
		}
	}
}
