using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskFlow.Application.Common.Pagination;
using TaskFlow.Application.Finders.Users.All;

namespace TaskFlow.Application.Queries.Users.Users
{
	internal class UsersQueryHandler : IRequestHandler<UsersQuery, PagedResult<ViewModels.UserItemVm>>
	{
		private readonly ILogger<UsersQueryHandler> _logger;
		private readonly IMapper _mapper;
		private readonly IUsersFinder _usersFinder;

		public UsersQueryHandler(
			ILogger<UsersQueryHandler> logger,
			IMapper mapper,
			IUsersFinder usersFinder)
		{
			_logger = logger;
			_mapper = mapper;
			_usersFinder = usersFinder;
		}

		public async Task<PagedResult<ViewModels.UserItemVm>> Handle(UsersQuery request, CancellationToken cancellationToken)
		{
			var users = await _usersFinder.FindAsync(
				new GetUsersParam(), new PageRequest(), cancellationToken);

			return _mapper.Map<PagedResult<ViewModels.UserItemVm>>(users);
		}
	}
}
