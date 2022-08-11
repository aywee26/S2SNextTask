using Ardalis.GuardClauses;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace S2SNextTask.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Guard.Against.Null(services, nameof(services));

        services.AddMediatR(typeof(DependencyInjection).Assembly);

        return services;
    }
}
