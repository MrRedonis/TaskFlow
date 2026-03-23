using TaskFlow.Application.Common.Finders;

namespace TaskFlow.Application.Finders.Issues.All
{
	public interface IIssuesFinder : ICollectionFinder<GetIssuesParams, IssueItemFm>
	{
	}
}
