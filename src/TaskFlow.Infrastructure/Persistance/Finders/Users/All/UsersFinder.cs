using AutoMapper;
using TaskFlow.Application.Common.Pagination;
using TaskFlow.Application.Extensions;
using TaskFlow.Application.Finders.Users.All;
using TaskFlow.Infrastructure.Persistance.Data;

namespace TaskFlow.Infrastructure.Persistance.Finders.Users.All
{
	internal class UsersFinder : IUsersFinder
	{
		private readonly IMapper _mapper;

		public UsersFinder(IMapper mapper)
		{
			_mapper = mapper;
		}

		public Task<PagedResult<UserItemFm>> FindAsync(GetUsersParam request, PageRequest pageRequest,
			CancellationToken cancellationToken = default)
		{
			var query = MockData.Users
				.AsEnumerable()
				.Select(x => _mapper.Map<UserItemFm>(x));

			var result = query.ToPagedResult(pageRequest);

			return Task.FromResult(result);
		}
	}
}
