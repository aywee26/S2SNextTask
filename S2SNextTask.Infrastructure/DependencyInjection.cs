using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using S2SNextTask.Application.Common.Interfaces.Persistence;
using S2SNextTask.Infrastructure.Persistence;
using S2SNextTask.Infrastructure.Persistence.Repositories;

namespace S2SNextTask.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
    {
        Guard.Against.Null(services, nameof(services));
        Guard.Against.Null(configuration, nameof(configuration));

        services.AddScoped(
            provider =>
            {
                var connectionStringName = configuration.GetConnectionString(nameof(AppDbContext));
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionStringName);
                var options = optionsBuilder.Options;
                return new AppDbContext(options);
            });

        services.AddTransient<IBooksRepository, BooksRepository>();

        return services;
    }
}
