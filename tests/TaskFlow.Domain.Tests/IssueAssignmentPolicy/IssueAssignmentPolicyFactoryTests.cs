using FluentAssertions;
using TaskFlow.Domain.Exceptions;
using TaskFlow.Domain.Users;
using TaskFlow.Domain.Users.Policies;

namespace TaskFlow.Domain.Tests.IssueAssignmentPolicy
{
	public class IssueAssignmentPolicyFactoryTests
	{
		[Fact]
		public void Should_Return_Developer_Policy()
		{
			var policy = IssueAssignmentPolicyFactory.Create(UserType.Developer);
			policy.Should().BeOfType<DeveloperIssueAssignmentPolicy>();
		}

		[Fact]
		public void Should_Return_DevopsAdministrator_Policy()
		{
			var policy = IssueAssignmentPolicyFactory.Create(UserType.DevOpsAdministrator);
			policy.Should().BeOfType<DevOpsIssueAssignmentPolicy>();
		}

		[Fact]
		public void Should_Throw_For_Unknown_User_Type()
		{
			Action act = () => IssueAssignmentPolicyFactory.Create((UserType)999);

			act.Should().Throw<DomainException>()
				.WithMessage("No assignment policy for user type*");
		}
	}
}
