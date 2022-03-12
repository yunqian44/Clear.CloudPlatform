using Clear.CloudPlatform.Application;
using Clear.CloudPlatform.Application.Common.Interfaces;
using Clear.CloudPlatform.Auth;
using Clear.CloudPlatform.Data;
using Clear.CloudPlatform.Data.Infrastructure;
using Clear.CloudPlatform.Data.SqlServer;
using Clear.CloudPlatform.Data.SqlServer.Infrastructure;
using Clear.CloudPlatform.Infrastructure;
using Clear.CloudPlatform.Infrastructure.Common;
using Clear.CloudPlatform.Infrastructure.Persistence;
using Clear.CloudPlatform.WebUI.Filters;
using Clear.CloudPlatform.WebUI.Services;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Clear.CloudPlatform.WebUI;

public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        Env = env;
    }

    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Env { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddSingleton(new Appsettings(Env.ContentRootPath));
        services.AddApplication();
        services.AddInfrastructure(Configuration);

        services.AddDatabaseDeveloperPageExceptionFilter();

        //AppDomain.CurrentDomain.Load("Clear.CloudPlatform.Application");

        //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        services.AddToolsAuthenticaton(Configuration);


        services.AddSqlServerStorage(Appsettings.app("ConnectionStrings", "ToolBlockDatabase"));
        

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        services.AddRazorPages();

        // Customise default API behaviour
        //services.Configure<ApiBehaviorOptions>(options => 
            //options.SuppressModelStateInvalidFilter = true);

        // In production, the Angular files will be served from this directory
        services.AddSpaStaticFiles(configuration => 
            configuration.RootPath = "ClientApp/dist");

        
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHealthChecks("/health");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        if (!env.IsDevelopment())
        {
            app.UseSpaStaticFiles();
        }

       

        app.UseRouting();

        app.UseAuthentication();
        //app.UseIdentityServer();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        });

        //app.UseSpa(spa =>
        //{
        //        // To learn more about options for serving an Angular SPA from ASP.NET Core,
        //        // see https://go.microsoft.com/fwlink/?linkid=864501

        //        spa.Options.SourcePath = "ClientApp";

        //    if (env.IsDevelopment())
        //    {
        //            //spa.UseAngularCliServer(npmScript: "start");
        //            spa.UseProxyToSpaDevelopmentServer(Configuration["SpaBaseUrl"] ?? "http://localhost:4200");
        //    }
        //});
    }
}
