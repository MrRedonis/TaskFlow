namespace TaskFlow.Domain.Shared
{
	public abstract class AggregateRoot<TId> : AggregateRoot
	{
		public TId Id { get; private set; }

		protected AggregateRoot(TId id)
		{
			Id = id;
		}
	}

	public abstract class AggregateRoot
	{
		private readonly List<IDomainEvent> _domainEvents = new();

		public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

		protected void AddDomainEvent(IDomainEvent @event)
		{
			_domainEvents.Add(@event);
		}

		public void ClearDomainEvents()
		{
			_domainEvents.Clear();
		}
	}
}
