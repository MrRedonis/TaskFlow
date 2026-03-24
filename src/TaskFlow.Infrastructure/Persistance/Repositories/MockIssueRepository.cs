using TaskFlow.Application.Repositories;
using TaskFlow.Domain.Exceptions;
using TaskFlow.Domain.Issues;
using TaskFlow.Infrastructure.Persistance.Db;

namespace TaskFlow.Infrastructure.Persistance.Repositories
{
	internal class MockIssueRepository : IIssueRepository
	{
		private readonly InMemoryDatabase _database;

		public MockIssueRepository(InMemoryDatabase database)
		{
			_database = database;
		}

		public async Task<Issue?> GetByIdAsync(IssueId issueId, CancellationToken cancellationToken = default)
		{
			return _database.Issues.Find(x => x.Id == issueId);
		}

		public async Task<IReadOnlyList<Issue>> GetByIdsAsync(IEnumerable<IssueId> issueIds, CancellationToken cancellationToken = default)
		{
			return _database.Issues.Where(x => issueIds.Contains(x.Id)).ToList();
		}

		public Task UpdateRangeAsync(IReadOnlyList<Issue> issues, CancellationToken cancellationToken)
		{
			if (issues is null || issues.Count == 0)
				return Task.CompletedTask;

			var indexMap = new Dictionary<IssueId, int>();

			for (var i = 0; i < _database.Issues.Count; i++)
			{
				indexMap[_database.Issues[i].Id] = i;
			}

			foreach (var issue in issues)
			{
				if (!indexMap.ContainsKey(issue.Id))
					throw new DomainException($"Issue with id {issue.Id} not found");
			}

			foreach (var issue in issues)
			{
				var index = indexMap[issue.Id];
				_database.Issues[index] = issue;
				_database.Track(issue);
			}

			return Task.CompletedTask;
		}

		public Task UpdateAsync(Issue issue, CancellationToken cancellationToken = default)
		{
			var index = _database.Issues.FindIndex(x => x.Id == issue.Id);
			if (index >= 0)
			{
				_database.Issues[index] = issue;
				_database.Track(issue);
			}

			return Task.CompletedTask;
		}
	}
}
