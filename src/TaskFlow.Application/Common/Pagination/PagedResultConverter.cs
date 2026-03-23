using AutoMapper;

namespace TaskFlow.Application.Common.Pagination
{
	public class PagedResultConverter<TSource, TDestination>
		: ITypeConverter<PagedResult<TSource>, PagedResult<TDestination>>
	{
		public PagedResult<TDestination> Convert(
			PagedResult<TSource> source,
			PagedResult<TDestination> destination,
			ResolutionContext context)
		{
			if (source == null) return null;

			var mappedItems = context.Mapper.Map<IReadOnlyCollection<TDestination>>(source.Items);

			return PagedResult<TDestination>.Create(
				mappedItems,
				source.TotalCount,
				source.PageNumber,
				source.PageSize
			);
		}
	}
}
