namespace TaskFlow.Domain.Shared
{
	public abstract class AggregateRoot<TId>
	{
		private readonly List<IDomainEvent> _domainEvents = new();

		public TId Id { get; private set; }

		public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

		protected AggregateRoot(TId id)
		{
			Id = id;
		}

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
