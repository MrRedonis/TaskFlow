using TaskFlow.Domain.Issues;
using TaskFlow.Domain.Shared;

namespace TaskFlow.Domain.Users.Events
{
	public record UserIssuesAssignedEvent(UserId UserId, IReadOnlyCollection<IssueId> IssueIds, DateTime OccurredOn) : IDomainEvent
	{
		public UserIssuesAssignedEvent(UserId userId, IEnumerable<IssueId> issueIds) 
			: this(userId, issueIds.ToList().AsReadOnly(), DateTime.UtcNow)
		{
		}
	}
}
