using TaskFlow.Application.Common.Pagination;

namespace TaskFlow.Application.Common.Finders
{
	public interface ICollectionFinder<in TRequest, TResponse> 
	{
		Task<PagedResult<TResponse>> FindAsync(TRequest request, PageRequest pageRequest, CancellationToken cancellationToken = default);
	}
}
