using MediatR;
using TaskFlow.Application.Common.Pagination;
using TaskFlow.Application.Queries.Users.Users.ViewModels;

namespace TaskFlow.Application.Queries.Users.Users
{
	public sealed record UsersQuery : IRequest<PagedResult<UserItemVm>>;
}
