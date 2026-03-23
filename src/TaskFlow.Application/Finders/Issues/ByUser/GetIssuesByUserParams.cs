namespace TaskFlow.Application.Finders.Issues.ByUser
{
	public class GetIssuesByUserParams
	{
		public Guid UserId { get; set; }
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
