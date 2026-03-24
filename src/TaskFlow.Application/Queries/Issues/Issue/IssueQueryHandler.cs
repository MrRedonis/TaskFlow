using AutoMapper;
using MediatR;
using TaskFlow.Application.Finders.Issues.ById;
using TaskFlow.Application.Queries.Issues.Issue.ViewModels;

namespace TaskFlow.Application.Queries.Issues.Issue
{
	internal class IssueQueryHandler : IRequestHandler<IssueQuery, IssueDetailVm?>
	{
		private readonly IIssueByIdFinder _issuesFinder;
		private readonly IMapper _mapper;

		public IssueQueryHandler(
			IIssueByIdFinder issuesFinder,
			IMapper mapper)
		{
			_issuesFinder = issuesFinder;
			_mapper = mapper;
		}

		public async Task<IssueDetailVm?> Handle(IssueQuery request, CancellationToken cancellationToken)
		{
			var param = new IssueByIdParams{ Id = request.IssueId };
			var result = await _issuesFinder.FindAsync(param, cancellationToken);
			return _mapper.Map<IssueDetailVm>(result);
		}
	}
}
