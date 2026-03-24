using AutoMapper;
using TaskFlow.Application.Finders.Users.User;
using TaskFlow.Infrastructure.Persistance.Data;
using TaskFlow.Infrastructure.Persistance.Db;

namespace TaskFlow.Infrastructure.Persistance.Finders.Users.User
{
	internal class UserFinder : IUserFinder
	{
		private readonly IMapper _mapper;
		private readonly InMemoryDatabase _database;

		public UserFinder(IMapper mapper, InMemoryDatabase database)
		{
			_mapper = mapper;
			_database = database;
		}

		public Task<UserFm> FindAsync(GetUserParam request, CancellationToken cancellationToken = default)
		{
			var user = _database.Users.Find(x => x.Id == request.UserId);
			return Task.FromResult(_mapper.Map<UserFm>(user));
		}
	}
}
