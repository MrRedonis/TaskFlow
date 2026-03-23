using TaskFlow.Domain.Exceptions;
using TaskFlow.Domain.Issues;
using TaskFlow.Domain.Shared;
using TaskFlow.Domain.Users.Events;
using TaskFlow.Domain.Users.Policies;

namespace TaskFlow.Domain.Users
{
	public class User : AggregateRoot<UserId>
	{
		private readonly List<IssueAssignment> _assignments = new();

		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string Email { get; private set; }
		public UserType Type { get; private set; }
		public IReadOnlyCollection<IssueAssignment> Assignments => _assignments;

		public User(UserId id, string firstName, string lastName, string email, UserType type) : base(id)
		{
			if (string.IsNullOrWhiteSpace(firstName))
			{
				throw new DomainException("First name cannot be empty");
			}

			if (string.IsNullOrWhiteSpace(lastName))
			{
				throw new DomainException("Last name cannot be empty");
			}

			if (string.IsNullOrWhiteSpace(email))
			{
				throw new DomainException("Email cannot be empty");
			}

			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Type = type;
		}

		public User(UserId id, string firstName, string lastName, string email, UserType type, IEnumerable<IssueAssignment> assignments) 
			: this(id, firstName, lastName, email, type)
		{
			_assignments.AddRange(assignments);
		}

		public void AssignIssues(IEnumerable<Issue> issues)
		{
			var newIssues = issues.ToList();

			if (!newIssues.Any())
				throw new DomainException("No issues provided");

			var policy = IssueAssignmentPolicyFactory.Create(Type);
			policy.Validate(this, newIssues);

			foreach (var issue in newIssues)
			{
				issue.AssignTo(Id); 
				_assignments.Add(new IssueAssignment(issue));
			}
			
			AddDomainEvent(new UserIssuesAssignedEvent(Id, newIssues.Select(i => i.Id).ToList()));
		}

		public void AssignIssue(Issue issue)
		{
			AssignIssues(new[] { issue });
		}
	}
}
