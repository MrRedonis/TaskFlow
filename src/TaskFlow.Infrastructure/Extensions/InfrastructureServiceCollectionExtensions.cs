using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Common.UnitOfWorks;
using TaskFlow.Application.Extensions;
using TaskFlow.Application.Finders.Issues.All;
using TaskFlow.Application.Finders.Issues.ById;
using TaskFlow.Application.Finders.Issues.ByUser;
using TaskFlow.Application.Finders.Users.All;
using TaskFlow.Application.Finders.Users.User;
using TaskFlow.Application.Repositories;
using TaskFlow.Infrastructure.Persistance.Db;
using TaskFlow.Infrastructure.Persistance.Finders.Issues.All;
using TaskFlow.Infrastructure.Persistance.Finders.Issues.ById;
using TaskFlow.Infrastructure.Persistance.Finders.Issues.ByUser;
using TaskFlow.Infrastructure.Persistance.Finders.Users.All;
using TaskFlow.Infrastructure.Persistance.Finders.Users.User;
using TaskFlow.Infrastructure.Persistance.Repositories;
using TaskFlow.Infrastructure.Persistance.UnitOfWorks;

namespace TaskFlow.Infrastructure.Extensions
{
	public static class InfrastructureServiceCollectionExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddScoped<IUserRepository, MockUserRepository>();
			services.AddScoped<IIssueRepository, MockIssueRepository>();

			services.AddScoped<IIssuesFinder, IssuesFinder>();
			services.AddScoped<IUsersFinder, UsersFinder>();
			services.AddScoped<IUserFinder, UserFinder>();
			services.AddScoped<IIssuesByUserFinder, IssuesByUserFinder>();
			services.AddScoped<IIssueByIdFinder, IssueByIdFinder>();

			services.AddSingleton<InMemoryDatabase>();

			services.AddAutoMapper(_ => {},
				typeof(ApplicationServiceCollectionExtensions).Assembly,
				typeof(InfrastructureServiceCollectionExtensions).Assembly
			);

			services.AddScoped<IUnitOfWork, InMemoryUnitOfWork>();

			return services;
		}
	}
}
