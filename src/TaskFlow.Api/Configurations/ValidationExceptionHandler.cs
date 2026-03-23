using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Api.Configurations
{
	internal class ValidationExceptionHandler : IExceptionHandler
	{
		private readonly IProblemDetailsService _problemDetailsService;
		private readonly ILogger<ValidationExceptionHandler> _logger;

		public ValidationExceptionHandler(
			IProblemDetailsService problemDetailsService,
			ILogger<ValidationExceptionHandler> logger)
		{
			_problemDetailsService = problemDetailsService;
			_logger = logger;
		}

		public async ValueTask<bool> TryHandleAsync(
			HttpContext httpContext,
			Exception exception,
			CancellationToken cancellationToken)
		{
			if (exception is not ValidationException validationException)
				return false;

			var errors = validationException.Errors
				.GroupBy(e => e.PropertyName)
				.ToDictionary(
					g => g.Key,
					g => g.Select(e => e.ErrorMessage).ToArray()
				);

			var problemDetails = new ValidationProblemDetails(errors)
			{
				Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
				Title = "Validation failed",
				Status = StatusCodes.Status400BadRequest,
				Detail = "One or more validation errors occurred.",
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
