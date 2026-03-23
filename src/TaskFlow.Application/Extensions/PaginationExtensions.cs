using TaskFlow.Application.Common.Pagination;

namespace TaskFlow.Application.Extensions
{
	public static class PaginationExtensions
	{
		public static PagedResult<T> ToPagedResult<T>(
			this IEnumerable<T> source,
			PageRequest pageRequest)
		{
			var totalCount = source.Count();

			var items = source
				.Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize)
				.Take(pageRequest.PageSize)
				.ToList();

			return PagedResult<T>.Create(
				items,
				totalCount,
				pageRequest.PageNumber,
				pageRequest.PageSize);
		}
	}
}
