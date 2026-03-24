using TaskFlow.Application.Common.Events;
using TaskFlow.Application.Common.UnitOfWorks;
using TaskFlow.Infrastructure.Persistance.Db;

namespace TaskFlow.Infrastructure.Persistance.UnitOfWorks
{
	internal class InMemoryUnitOfWork : IUnitOfWork
	{
		private readonly InMemoryDatabase _db;
		private readonly IDomainEventAdapter _eventAdapter;

		public InMemoryUnitOfWork(InMemoryDatabase db, IDomainEventAdapter eventAdapter)
		{
			_db = db;
			_eventAdapter = eventAdapter;
		}

		public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var aggregates = _db.GetTrackedAggregates();
			var events = aggregates.SelectMany(a => a.DomainEvents).ToList();

			foreach (var aggregate in aggregates)
				aggregate.ClearDomainEvents();

			_db.ClearTracked();

			await _eventAdapter.PublishAsync(events, cancellationToken);
		}
	}
}
