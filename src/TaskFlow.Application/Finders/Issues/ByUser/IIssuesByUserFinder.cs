using TaskFlow.Application.Common.Finders;

namespace TaskFlow.Application.Finders.Issues.ByUser
{
	public interface IIssuesByUserFinder : ICollectionFinder<GetIssuesByUserParams, AssignedIssueFm>
	{
	}
}
