using Clear.CloudPlatform.Data;
using Clear.CloudPlatform.Data.SqlServer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clear.CloudPlatform.WebUI;

public static class WebApplicationExtensions
{
    public static async Task<StartupInitResult> InitStartUp(this IHost host)
    {
        try
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var env = services.GetRequiredService<IWebHostEnvironment>();

            var context = services.GetRequiredService<SqlServerDbContext>();
            
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var logger = loggerFactory.CreateLogger<Program>();
            bool canConnect = await context.Database.CanConnectAsync();
            if (!canConnect) return StartupInitResult.DatabaseConnectionFail;

            await context.Database.EnsureCreatedAsync();

            bool isNewEnv= !await context.Menu.AnyAsync();
            if (isNewEnv)
            {
                try
                {

                    logger.LogInformation("Seeding database...");

                    await context.ClearAllData();
                    await Seed.SeedAsync(context, logger);

                    logger.LogInformation("Database seeding successfully.");
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return StartupInitResult.None;

            
        }
        catch (Exception e)
        {
            return StartupInitResult.DatabaseSetupFail;
        }
        
    }
}

public enum StartupInitResult
{
    None = 0,
    DatabaseConnectionFail = 1,
    DatabaseSetupFail = 2
}
