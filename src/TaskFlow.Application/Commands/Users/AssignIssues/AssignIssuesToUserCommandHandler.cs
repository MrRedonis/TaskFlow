using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskFlow.Application.Repositories;
using TaskFlow.Domain.Exceptions;
using TaskFlow.Domain.Issues;
using TaskFlow.Domain.Users;

namespace TaskFlow.Application.Commands.Users.AssignIssues
{
	internal class AssignIssuesToUserCommandHandler : IRequestHandler<AssignIssuesToUserCommand, Result>
	{
		private readonly ILogger<AssignIssuesToUserCommandHandler> _logger;
		private readonly IIssueRepository _issueRepository;
		private readonly IUserRepository _userRepository;

		public AssignIssuesToUserCommandHandler(
			ILogger<AssignIssuesToUserCommandHandler> logger,
			IIssueRepository issueRepository,
			IUserRepository userRepository)
		{
			_logger = logger;
			_issueRepository = issueRepository;
			_userRepository = userRepository;
		}

		public async Task<Result> Handle(AssignIssuesToUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdAsync(new UserId(request.UserId), cancellationToken)
			           ?? throw new DomainException("User not found");

			var issueIds = request.IssueIds.Select(id => new IssueId(id)).ToList();
			var issues = await _issueRepository.GetByIdsAsync(issueIds, cancellationToken);

			if (issues.Count != issueIds.Count)
				throw new DomainException("Some issues not found");

			user.AssignIssues(issues);

			foreach (var issue in issues)
			{
				issue.AssignTo(user.Id);
			}

			await _userRepository.UpdateAsync(user, cancellationToken);
			await _issueRepository.UpdateRangeAsync(issues, cancellationToken);

			return Result.Ok();
		}
	}
}
