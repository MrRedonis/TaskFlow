using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskFlow.Application.Finders.Users.User;
using TaskFlow.Domain.Users;

namespace TaskFlow.Application.Queries.Users.User
{
	internal class UserQueryHandler : IRequestHandler<UserQuery, ViewModels.UserVm>
	{
		private readonly ILogger<UserQueryHandler> _logger;
		private readonly IMapper _mapper;
		private readonly IUserFinder _userFinder;

		public UserQueryHandler(
			ILogger<UserQueryHandler> logger,
			IMapper mapper,
			IUserFinder userFinder)
		{
			_logger = logger;
			_mapper = mapper;
			_userFinder = userFinder;
		}

		public async Task<ViewModels.UserVm> Handle(UserQuery request, CancellationToken cancellationToken)
		{
			var user = await _userFinder.FindAsync(new GetUserParam(new UserId(request.UserId)), cancellationToken);
			return _mapper.Map<ViewModels.UserVm>(user);
		}
	}
}
