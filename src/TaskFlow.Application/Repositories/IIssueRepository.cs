using TaskFlow.Domain.Issues;

namespace TaskFlow.Application.Repositories
{
	public interface IIssueRepository
	{
		Task<Issue?> GetByIdAsync(IssueId issueId, CancellationToken cancellationToken = default);
		Task<IReadOnlyList<Issue>> GetByIdsAsync(IEnumerable<IssueId> issueIds, CancellationToken cancellationToken = default);
		Task UpdateRangeAsync(IReadOnlyList<Issue> issues, CancellationToken cancellationToken);
	}
}
