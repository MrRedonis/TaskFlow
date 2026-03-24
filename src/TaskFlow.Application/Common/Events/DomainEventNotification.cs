using MediatR;
using TaskFlow.Domain.Shared;

namespace TaskFlow.Application.Common.Events
{
	public class DomainEventNotification<TDomainEvent> : INotification 
		where TDomainEvent : IDomainEvent
	{
		public TDomainEvent DomainEvent { get; }

		public DomainEventNotification(TDomainEvent domainEvent)
		{
			DomainEvent = domainEvent;
		}
	}
}
