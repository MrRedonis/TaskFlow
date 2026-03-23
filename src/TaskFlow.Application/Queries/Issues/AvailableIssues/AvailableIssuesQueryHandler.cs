using AutoMapper;
using MediatR;
using TaskFlow.Application.Common.Pagination;
using TaskFlow.Application.Finders.Issues.All;
using TaskFlow.Application.Queries.Issues.AvailableIssues.ViewModels;

namespace TaskFlow.Application.Queries.Issues.AvailableIssues
{
	internal class AvailableIssuesQueryHandler : IRequestHandler<AvailableIssuesQuery, PagedResult<AvailableIssueVm>>
	{
		private readonly IIssuesFinder _issuesFinder;
		private readonly IMapper _mapper;

		public AvailableIssuesQueryHandler(
			IIssuesFinder issuesFinder, 
			IMapper mapper)
		{
			_issuesFinder = issuesFinder;
			_mapper = mapper;
		}

		public async Task<PagedResult<AvailableIssueVm>> Handle(AvailableIssuesQuery request, CancellationToken cancellationToken)
		{
			var param = new GetIssuesParams
			{
				Available = true
			};

			var pageRequest = new PageRequest { PageNumber = request.Page, PageSize = request.PageSize };
			var availableIssues = await _issuesFinder.FindAsync(param, pageRequest, cancellationToken);

			return _mapper.Map<PagedResult<AvailableIssueVm>>(availableIssues);
		}
	}
}
