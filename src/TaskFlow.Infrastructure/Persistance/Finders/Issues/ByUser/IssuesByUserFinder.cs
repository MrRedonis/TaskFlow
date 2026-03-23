using AutoMapper;
using TaskFlow.Application.Common.Pagination;
using TaskFlow.Application.Extensions;
using TaskFlow.Application.Finders.Issues.ByUser;
using TaskFlow.Infrastructure.Persistance.Data;

namespace TaskFlow.Infrastructure.Persistance.Finders.Issues.ByUser
{
	internal class IssuesByUserFinder : IIssuesByUserFinder
	{
		private readonly IMapper _mapper;

		public IssuesByUserFinder(IMapper mapper)
		{
			_mapper = mapper;
		}

		public Task<PagedResult<AssignedIssueFm>> FindAsync(GetIssuesByUserParams request, PageRequest pageRequest, CancellationToken cancellationToken = default)
		{
			var query = MockData.Issues.AsEnumerable()
				.Where(x => x.UserId.HasValue && x.UserId.Value == request.UserId)
				.OrderByDescending(x => x.Difficulty)
				.Select(_mapper.Map<AssignedIssueFm>);

			var result = query.ToPagedResult(pageRequest);

			return Task.FromResult(result);
		}
	}
}
