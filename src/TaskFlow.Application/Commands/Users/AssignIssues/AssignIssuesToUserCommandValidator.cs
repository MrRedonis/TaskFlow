using FluentValidation;

namespace TaskFlow.Application.Commands.Users.AssignIssues
{
	internal class AssignIssuesToUserCommandValidator : AbstractValidator<AssignIssuesToUserCommand>
	{
		public AssignIssuesToUserCommandValidator()
		{
			RuleFor(c => c.IssueIds)
				.NotEmpty()
				.WithMessage("IssueIds cannot be empty")
				.Must(x => x.Count <= 10)
				.WithMessage("Cannot assign more than 10 issues at once")
				.Must(HaveNoDuplicates)
				.WithMessage("IssueIds contains duplicate values.");
		}

		private static bool HaveNoDuplicates(IReadOnlyCollection<Guid> ids) => ids.Distinct().Count() == ids.Count;
	}
}
