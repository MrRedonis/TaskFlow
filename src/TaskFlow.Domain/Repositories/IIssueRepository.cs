using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Repositories
{
	public interface IIssueRepository
	{
		Task<IEnumerable<Issue>> GetAllAsync(CancellationToken cancellationToken = default);
		Task<Issue?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
	}
}
