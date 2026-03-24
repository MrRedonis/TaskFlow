using MediatR;
using Microsoft.Extensions.Logging;
using TaskFlow.Application.Common.Events;
using TaskFlow.Domain.Users.Events;

namespace TaskFlow.Application.Events
{
	internal class UserIssuesAssignedEventHandler : INotificationHandler<DomainEventNotification<UserIssuesAssignedEvent>>
	{
		private readonly ILogger<UserIssuesAssignedEventHandler> _logger;
		public UserIssuesAssignedEventHandler(ILogger<UserIssuesAssignedEventHandler> logger)
		{
			_logger = logger;
		}

		public Task Handle(DomainEventNotification<UserIssuesAssignedEvent> notification, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
