using AutoMapper;
using TaskFlow.Application.Common.Pagination;
using TaskFlow.Application.Extensions;
using TaskFlow.Application.Finders.Users.All;
using TaskFlow.Infrastructure.Persistance.Db;

namespace TaskFlow.Infrastructure.Persistance.Finders.Users.All
{
	internal class UsersFinder : IUsersFinder
	{
		private readonly IMapper _mapper;
		private readonly InMemoryDatabase _database;

		public UsersFinder(IMapper mapper, InMemoryDatabase database)
		{
			_mapper = mapper;
			_database = database;
		}

		public Task<PagedResult<UserItemFm>> FindAsync(GetUsersParam request, PageRequest pageRequest,
			CancellationToken cancellationToken = default)
		{
			var query = _database.Users
				.AsEnumerable()
				.Select(_mapper.Map<UserItemFm>);

			var result = query.ToPagedResult(pageRequest);

			return Task.FromResult(result);
		}
	}
}
