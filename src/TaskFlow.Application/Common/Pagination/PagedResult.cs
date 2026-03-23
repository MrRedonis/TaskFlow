namespace TaskFlow.Application.Common.Pagination
{
	public sealed class PagedResult<T>
	{
		public IReadOnlyCollection<T> Items { get; init; } = Array.Empty<T>();

		public int PageNumber { get; init; }
		public int PageSize { get; init; }
		public int TotalCount { get; init; }
		public int TotalPages => PageSize == 0 ? 0 : (int)Math.Ceiling((double)TotalCount / PageSize);

		public bool HasNextPage => PageNumber < TotalPages;
		public bool HasPreviousPage => PageNumber > 1;

		public static PagedResult<T> Create(
			IReadOnlyCollection<T> items,
			int totalCount,
			int pageNumber,
			int pageSize)
		{
			return new PagedResult<T>
			{
				Items = items,
				TotalCount = totalCount,
				PageNumber = pageNumber,
				PageSize = pageSize
			};
		}
	}
}
