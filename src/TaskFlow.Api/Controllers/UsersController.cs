using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskFlow.Application.Commands.Users.AssignIssues;
using TaskFlow.Application.Commands.Users.AssignIssues.DTOs;
using TaskFlow.Application.Queries.Users.User;
using TaskFlow.Application.Queries.Users.User.ViewModels;
using TaskFlow.Application.Queries.Users.UserIssues;
using TaskFlow.Application.Queries.Users.UserIssues.ViewModels;
using TaskFlow.Application.Queries.Users.Users;
using TaskFlow.Application.Queries.Users.Users.ViewModels;

namespace TaskFlow.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly ILogger<UsersController> _logger;
		private readonly IMediator _mediator;

		public UsersController(ILogger<UsersController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		/// <summary>
		/// Get all users.
		/// </summary>
		/// <returns>List of users.</returns>
		[HttpGet]
		[ProducesResponseType(typeof(ICollection<UserItemVm>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetUsers()
		{
			var result = await _mediator.Send(new UsersQuery());
			return Ok(result);
		}

		/// <summary>
		/// Get user by ID.
		/// </summary>
		/// <param name="userId">User ID.</param>
		[HttpGet("{userId:guid}")]
		[ProducesResponseType(typeof(UserVm), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> GetUser(Guid userId)
		{
			var result = await _mediator.Send(new UserQuery(userId));
			return result is null ? NotFound() : Ok(result);
		}

		/// <summary>
		/// Get issues assigned to the user.
		/// </summary>
		[HttpGet("{userId:guid}/issues")]
		[ProducesResponseType(typeof(ICollection<IssueVm>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetUserIssues(Guid userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
		{
			var result = await _mediator.Send(new UserIssuesQuery(userId, page, Math.Min(pageSize, 10)));
			return Ok(result);
		}

		/// <summary>
		/// Assign issues to the user.
		/// </summary>
		[HttpPost("{userId:guid}/issues")]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
		public async Task<IActionResult> AssignIssues(Guid userId, [FromBody] AssignIssuesToUserDto dto)
		{
			var result = await _mediator.Send(new AssignIssuesToUserCommand(userId, dto.IssueIds));
			
			return result.IsSuccess ? NoContent() : BadRequest(result.Errors);
		}
	}
}
