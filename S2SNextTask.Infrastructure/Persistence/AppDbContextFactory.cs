﻿using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace S2SNextTask.Infrastructure.Persistence;

internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var creator = new AppDbContextCreator<AppDbContext>(
            builder =>
            {
                builder.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
            },
            options =>
            {
                var instance = new AppDbContext(options);
                return instance;
            });

        var instance = creator.CreateDbContext(args);
        return instance;
    }
}
