namespace TaskFlow.Application.Common.UnitOfWorks
{
	public interface IUnitOfWork
	{
		Task SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
