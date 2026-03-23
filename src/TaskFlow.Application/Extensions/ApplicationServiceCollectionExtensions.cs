using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Commands.Users.AssignIssues;
using TaskFlow.Application.Common.Behaviors;

namespace TaskFlow.Application.Extensions
{
	public static class ApplicationServiceCollectionExtensions
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			var assembly = typeof(ApplicationServiceCollectionExtensions).Assembly;

			services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssembly(assembly);
			});

			services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);

			services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			return services;
		}
	}
}
