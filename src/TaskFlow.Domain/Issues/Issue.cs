using TaskFlow.Domain.Exceptions;
using TaskFlow.Domain.Shared;
using TaskFlow.Domain.Users;

namespace TaskFlow.Domain.Issues
{
	public abstract class Issue : AggregateRoot<IssueId>
	{
		public abstract IssueType Type { get; }
		public string Title { get; protected set; }
		public IssueDifficulty Difficulty { get; protected set; }
		public Guid? UserId { get; protected set; }
		public IssueStatus Status { get; protected set; }
		public bool IsAssigned => UserId is not null;
		
		protected Issue(IssueId id, string title, IssueDifficulty difficulty, IssueStatus status = IssueStatus.Pending) : base(id)
		{
			if (string.IsNullOrWhiteSpace(title))
			{
				throw new DomainException("Title cannot be empty");
			}

			Title = title;
			Difficulty = difficulty;
			Status = status;
		}

		public void AssignTo(UserId userId)
		{
			if (IsAssigned)
				throw new DomainException("Issue already assigned");

			UserId = userId.Value;
		}

		public void Complete()
		{
			if (Status == IssueStatus.Completed)
				throw new DomainException("Issue already completed");

			Status = IssueStatus.Completed;
		}
	}
}
