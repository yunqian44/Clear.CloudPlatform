using Clear.CloudPlatform.Data.SqlServer;
using MediatR;

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
            //var context = new SqlServerDbContext();

            bool canConnect = await context.Database.CanConnectAsync();
            if (!canConnect) return StartupInitResult.DatabaseConnectionFail;

            await context.Database.EnsureCreatedAsync();

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
