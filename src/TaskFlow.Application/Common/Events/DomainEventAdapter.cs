using MediatR;
using TaskFlow.Domain.Shared;

namespace TaskFlow.Application.Common.Events
{
	public interface IDomainEventAdapter
	{
		Task PublishAsync(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken = default);
	}

	public class DomainEventAdapter : IDomainEventAdapter
	{
		private readonly IMediator _mediator;

		public DomainEventAdapter(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task PublishAsync(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken = default)
		{
			foreach (var domainEvent in events)
			{
				var notificationType = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
				var notification = (INotification)Activator.CreateInstance(notificationType, domainEvent)!;
				await _mediator.Publish(notification, cancellationToken);
			}
		}
	}
}
