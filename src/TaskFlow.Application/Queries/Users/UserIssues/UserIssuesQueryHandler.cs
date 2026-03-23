using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskFlow.Application.Common.Pagination;
using TaskFlow.Application.Finders.Issues.ByUser;

namespace TaskFlow.Application.Queries.Users.UserIssues
{
	internal class UserIssuesQueryHandler : IRequestHandler<UserIssuesQuery, PagedResult<ViewModels.IssueVm>>
	{
		private readonly ILogger<UserIssuesQueryHandler> _logger;
		private readonly IMapper _mapper;
		private readonly IIssuesByUserFinder _issuesByUserFinder;

		public UserIssuesQueryHandler(
			ILogger<UserIssuesQueryHandler> logger,
			IMapper mapper,
			IIssuesByUserFinder issuesByUserFinder)
		{
			_logger = logger;
			_mapper = mapper;
			_issuesByUserFinder = issuesByUserFinder;
		}

		public async Task<PagedResult<ViewModels.IssueVm>> Handle(UserIssuesQuery request, CancellationToken cancellationToken)
		{
			var param = new GetIssuesByUserParams{ UserId = request.UserId };
			var issues = await _issuesByUserFinder.FindAsync(param, new PageRequest(), cancellationToken);

			return _mapper.Map<PagedResult<ViewModels.IssueVm>>(issues);
		}
	}
}
