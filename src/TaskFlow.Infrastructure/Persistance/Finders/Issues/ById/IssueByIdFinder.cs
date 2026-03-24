using AutoMapper;
using TaskFlow.Application.Finders.Issues.ById;
using TaskFlow.Infrastructure.Persistance.Db;

namespace TaskFlow.Infrastructure.Persistance.Finders.Issues.ById
{
	internal class IssueByIdFinder : IIssueByIdFinder
	{
		private readonly IMapper _mapper;
		private readonly InMemoryDatabase _database;

		public IssueByIdFinder(IMapper mapper, InMemoryDatabase database)
		{
			_mapper = mapper;
			_database = database;
		}

		public Task<IssueDetailFm> FindAsync(IssueByIdParams request, CancellationToken cancellationToken = default)
		{
			var issue = _database.Issues.Find(x => x.Id.Value == request.Id);
			var result = _mapper.Map<IssueDetailFm>(issue);
			return Task.FromResult(result);
		}
	}
}
