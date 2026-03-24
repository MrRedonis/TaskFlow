using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskFlow.Application.Queries.Issues.AvailableIssues;
using TaskFlow.Application.Queries.Issues.AvailableIssues.ViewModels;
using TaskFlow.Application.Queries.Issues.Issue;
using TaskFlow.Application.Queries.Issues.Issue.ViewModels;

namespace TaskFlow.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class IssuesController : ControllerBase
	{
		private readonly ILogger<IssuesController> _logger;
		private readonly IMediator _mediator;

		public IssuesController(ILogger<IssuesController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		/// <summary>
		/// Get all available issues.
		/// </summary>
		/// <returns>List of available issues.</returns>
		[HttpGet("available")]
		[ProducesResponseType(typeof(ICollection<AvailableIssueVm>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetAvailable([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
		{
			var query = new AvailableIssuesQuery
			{
				Page = page,
				PageSize = Math.Min(pageSize, 10)
			};

			var result = await _mediator.Send(query);
			return Ok(result);
		}

		/// <summary>
		/// Get issue by ID.
		/// </summary>
		/// <param name="issueId">Issue ID.</param>
		[HttpGet("{issueId:guid}")]
		[ProducesResponseType(typeof(IssueDetailVm), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> GetIssue(Guid issueId)
		{
			var result = await _mediator.Send(new IssueQuery(issueId));
			return result is null ? NotFound() : Ok(result);
		}
	}
}
