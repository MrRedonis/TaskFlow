using TaskFlow.Domain.Issues;
using TaskFlow.Domain.Shared;
using TaskFlow.Domain.Users;
using TaskFlow.Infrastructure.Persistance.Data;

namespace TaskFlow.Infrastructure.Persistance.Db
{
	internal class InMemoryDatabase
	{
		public List<User> Users { get; }
		public List<Issue> Issues { get; }

		public InMemoryDatabase()
		{
			Users = MockData.Users;
			Issues = MockData.Issues;
		}

		private readonly HashSet<AggregateRoot> _tracked = new();

		public void Track(AggregateRoot aggregate) => _tracked.Add(aggregate);

		public IReadOnlyCollection<AggregateRoot> GetTrackedAggregates() => _tracked.ToList();

		public void ClearTracked() => _tracked.Clear();
	}
}
