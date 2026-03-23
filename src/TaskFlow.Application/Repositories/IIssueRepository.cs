using TaskFlow.Domain.Issues;

namespace TaskFlow.Application.Repositories
{
	public interface IIssueRepository
	{
		Task<IEnumerable<Issue>> GetAllAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<Issue>> GetAvailableAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<Issue>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
		Task<Issue?> GetByIdAsync(Guid issueId, CancellationToken cancellationToken = default);
		Task<IReadOnlyList<Issue>> GetByIdsAsync(IEnumerable<IssueId> issueIds, CancellationToken cancellationToken = default);
	}
}
