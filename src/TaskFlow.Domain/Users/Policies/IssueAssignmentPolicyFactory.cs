using TaskFlow.Domain.Exceptions;

namespace TaskFlow.Domain.Users.Policies
{
	public static class IssueAssignmentPolicyFactory
	{
		public static IIssueAssignmentPolicy Create(UserType userType)
		{
			return userType switch
			{
				UserType.Developer => new DeveloperIssueAssignmentPolicy(),
				UserType.DevOpsAdministrator => new DevOpsIssueAssignmentPolicy(),
				_ => throw new DomainException($"No assignment policy for user type {userType}.")
			};
		}
	}
}
