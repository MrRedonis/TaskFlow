namespace TaskFlow.Domain.Shared
{
	public interface IDomainEvent
	{
		DateTime OccurredOn { get; }
	}
}
