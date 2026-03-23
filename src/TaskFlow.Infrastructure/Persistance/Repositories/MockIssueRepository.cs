using TaskFlow.Application.Repositories;
using TaskFlow.Domain.Issues;
using TaskFlow.Infrastructure.Persistance.Data;

namespace TaskFlow.Infrastructure.Persistance.Repositories
{
	internal class MockIssueRepository : IIssueRepository
	{
		public async Task<IEnumerable<Issue>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return MockData.Issues;
		}

		public async Task<IEnumerable<Issue>> GetAvailableAsync(CancellationToken cancellationToken = default)
		{
			return MockData.Issues.Where(x => x.UserId == null);
		}

		public async Task<IEnumerable<Issue>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
		{
			return MockData.Issues.Where(x => x.UserId == userId);
		}

		public async Task<Issue?> GetByIdAsync(Guid issueId, CancellationToken cancellationToken = default)
		{
			return MockData.Issues.Find(x => x.Id.Value == issueId);
		}

		public async Task<IReadOnlyList<Issue>> GetByIdsAsync(IEnumerable<IssueId> issueIds, CancellationToken cancellationToken = default)
		{
			return MockData.Issues.Where(x => issueIds.Contains(x.Id)).ToList();
		}
	}
}
