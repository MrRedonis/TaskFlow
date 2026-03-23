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
			_logger.LogInformation("Assigning {IssueCount} issue(s) to user {UserId}", request.IssueIds.Count, request.UserId);

			var user = await _userRepository.GetByIdAsync(new UserId(request.UserId), cancellationToken);

			if (user == null)
			{
				_logger.LogWarning("User {UserId} not found", request.UserId);
				return Result.Fail("User not found");
			}

			var issueIds = request.IssueIds.Select(id => new IssueId(id)).ToList();
			var issues = (await _issueRepository.GetByIdsAsync(issueIds, cancellationToken)).ToList();

			if (issues.Count != issueIds.Count)
			{
				_logger.LogWarning("Some issues do not exist: {@IssueIds}", request.IssueIds);
				return Result.Fail("Some issues do not exist");
			}

			var alreadyAssigned = issues.Where(i => i.UserId is not null).ToList();
			if (alreadyAssigned.Any())
			{
				_logger.LogWarning("Some issues are already assigned: {@IssueIds}", alreadyAssigned.Select(i => i.Id));
				return Result.Fail("Some issues are already assigned");
			}

			try
			{
				user.AssignIssues(issues);
			}
			catch (DomainException ex)
			{
				_logger.LogWarning("Domain validation failed: {Message}", ex.Message);
				return Result.Fail("Domain validation failed");
			}

			await _userRepository.UpdateAsync(user, cancellationToken);

			return Result.Ok();
		}
	}
}
