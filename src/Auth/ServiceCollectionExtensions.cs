using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

namespace Clear.CloudPlatform.Auth;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddToolsAuthenticaton(this IServiceCollection services, IConfiguration configuration)
    {

        var section = configuration.GetSection("Authentication");
        var authentication = section.Get<AuthenticationSettings>();


        services.Configure<AuthenticationSettings>(section);
        services.AddScoped<IGetApiKeyQuery, AppSettingsGetApiKeyQuery>();


        services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        }).AddApiKeySupport(_ => { }).AddMicrosoftIdentityWebApp(configuration.GetSection("Authentication:AzureAd"));

        return services;
    }

}
