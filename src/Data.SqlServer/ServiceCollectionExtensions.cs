using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clear.CloudPlatform.Data.Infrastructure;
using Clear.CloudPlatform.Data.SqlServer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Clear.CloudPlatform.Data.SqlServer;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlServerStorage(this IServiceCollection services, string connectionString)
    {
        services.AddScoped(typeof(IRepository<>), typeof(SqlServerDbContextRepository<>));


        services.AddDbContext<SqlServerDbContext>(options =>
            options.UseLazyLoadingProxies()
                .UseSqlServer(connectionString, builder =>
                {
                    builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(30), null);
                }).
                EnableDetailedErrors());

        return services;
    }
}
