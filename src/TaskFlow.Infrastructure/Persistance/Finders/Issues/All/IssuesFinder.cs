using AutoMapper;
using TaskFlow.Application.Common.Pagination;
using TaskFlow.Application.Extensions;
using TaskFlow.Application.Finders.Issues.All;
using TaskFlow.Infrastructure.Persistance.Data;

namespace TaskFlow.Infrastructure.Persistance.Finders.Issues.All
{
	internal class IssuesFinder : IIssuesFinder
	{
		private readonly IMapper _mapper;

		public IssuesFinder(IMapper mapper)
		{
			_mapper = mapper;
		}

		public Task<PagedResult<IssueItemFm>> FindAsync(GetIssuesParams request, PageRequest pageRequest, CancellationToken cancellationToken = default)
		{
			var query = MockData.Issues
				.AsEnumerable();

			if (request.Available.HasValue)
			{
				query = query.Where(x => x.UserId.HasValue != request.Available.Value);
			}

			var result = query
				.OrderByDescending(x => x.Difficulty)
				.Select(_mapper.Map<IssueItemFm>)
				.ToPagedResult(pageRequest);

			return Task.FromResult(result);
		}
	}
}
