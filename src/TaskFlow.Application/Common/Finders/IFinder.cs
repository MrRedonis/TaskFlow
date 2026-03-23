namespace TaskFlow.Application.Common.Finders
{
	public interface IFinder<in TRequest, TResponse>
	{
		Task<TResponse> FindAsync(TRequest request, CancellationToken cancellationToken = default);
	}
}
