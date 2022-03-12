using System.Data;
using Clear.CloudPlatform.Auth;
using Clear.CloudPlatform.Data.SqlServer;
using Clear.CloudPlatform.Infrastructure.Common;
using Clear.CloudPlatform.Infrastructure.Identity;
using Clear.CloudPlatform.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clear.CloudPlatform.WebUI;

public class Program
{
    public static StartupInitResult InitResult { get; set; }

    public async static Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();


        InitResult= await host.InitStartUp();

        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
                webBuilder
            .UseUrls("http://*:9005")
            .UseStartup<Startup>());
}
