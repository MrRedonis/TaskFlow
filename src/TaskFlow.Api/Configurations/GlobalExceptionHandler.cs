using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Api.Configurations
{
	internal class GlobalExceptionHandler : IExceptionHandler
	{
		private readonly IHostEnvironment _environment;
		private readonly ILogger<GlobalExceptionHandler> _logger;
		private readonly IProblemDetailsService _problemDetailsService;

		public GlobalExceptionHandler(
			IHostEnvironment environment,
			ILogger<GlobalExceptionHandler> logger,
			IProblemDetailsService problemDetailsService)
		{
			_environment = environment;
			_logger = logger;
			_problemDetailsService = problemDetailsService;
		}

		public async ValueTask<bool> TryHandleAsync(
			HttpContext httpContext,
			Exception exception,
			CancellationToken cancellationToken)
		{
			_logger.LogError(exception, "Unhandled exception");

			var problemDetails = new ProblemDetails
			{
				Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
				Title = "Internal Server Error",
				Status = StatusCodes.Status500InternalServerError,
				Detail = _environment.IsDevelopment() ? exception.ToString() : "An internal server error occurred",
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
