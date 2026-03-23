using AutoMapper;
using TaskFlow.Application.Finders.Users.User;
using TaskFlow.Infrastructure.Persistance.Data;

namespace TaskFlow.Infrastructure.Persistance.Finders.Users.User
{
	internal class UserFinder : IUserFinder
	{
		private readonly IMapper _mapper;

		public UserFinder(IMapper mapper)
		{
			_mapper = mapper;
		}

		public Task<UserFm> FindAsync(GetUserParam request, CancellationToken cancellationToken = default)
		{
			var user = MockData.Users.Find(x => x.Id == request.UserId);
			return Task.FromResult(_mapper.Map<UserFm>(user));
		}
	}
}
