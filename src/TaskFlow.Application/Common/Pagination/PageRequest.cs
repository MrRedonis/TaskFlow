namespace TaskFlow.Application.Common.Pagination
{
	public sealed class PageRequest
	{
		public int PageNumber { get; init; } = 1;
		public int PageSize { get; init; } = 10;
	}
}
