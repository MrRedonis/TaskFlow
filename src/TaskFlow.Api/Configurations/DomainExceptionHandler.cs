using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Domain.Exceptions;

namespace TaskFlow.Api.Configurations
{
	internal class DomainExceptionHandler : IExceptionHandler
	{
		private readonly IProblemDetailsService _problemDetailsService;
		private readonly ILogger<DomainExceptionHandler> _logger;

		public DomainExceptionHandler(
			IProblemDetailsService problemDetailsService,
			ILogger<DomainExceptionHandler> logger)
		{
			_problemDetailsService = problemDetailsService;
			_logger = logger;
		}

		public async ValueTask<bool> TryHandleAsync(
			HttpContext httpContext,
			Exception exception,
			CancellationToken cancellationToken)
		{
			if (exception is not DomainException domainException)
			{
				return false;
			}

			_logger.LogWarning(exception, "Domain validation failed: {Message}", domainException.Message);

			var problemDetails = new ProblemDetails
			{
				Type = "https://tools.ietf.org/html/rfc4918#section-11.2",
				Title = "Domain rule violation",
				Status = StatusCodes.Status422UnprocessableEntity,
				Detail = domainException.Message,
				Instance = httpContext.Request.Path,
				Extensions =
				{
					["traceId"] = httpContext.TraceIdentifier
				}
			};

			httpContext.Response.StatusCode = problemDetails.Status.Value;

			await _problemDetailsService.WriteAsync(new ProblemDetailsContext
			{
				HttpContext = httpContext,
				ProblemDetails = problemDetails
			});

			return true;
		}
	}
}
