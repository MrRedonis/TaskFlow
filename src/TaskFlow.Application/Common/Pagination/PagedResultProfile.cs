using AutoMapper;

namespace TaskFlow.Application.Common.Pagination
{
	internal class PagedResultProfile : Profile
	{
		public PagedResultProfile()
		{
			CreateMap(typeof(PagedResult<>), typeof(PagedResult<>))
				.ConvertUsing(typeof(PagedResultConverter<,>));
		}
	}
}
