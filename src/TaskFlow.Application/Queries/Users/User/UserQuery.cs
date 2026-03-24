using MediatR;

namespace TaskFlow.Application.Queries.Users.User
{
	public sealed record UserQuery(Guid UserId) : IRequest<ViewModels.UserVm?>;
}
