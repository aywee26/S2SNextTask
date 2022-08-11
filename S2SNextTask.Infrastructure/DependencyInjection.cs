using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using S2SNextTask.Application.Common.Interfaces.Persistence;
using S2SNextTask.Infrastructure.Persistence.Repositories;

namespace S2SNextTask.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(this IServiceCollection services)
    {
        Guard.Against.Null(services, nameof(services));

        services.AddScoped<IBooksRepository, BooksRepository>();

        return services;
    }
}
