using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Clear.CloudPlatform.Auth;

public class ApiKeyAuthenticationOptions: AuthenticationSchemeOptions
{
    public const string DefaultScheme = "APIKey";
    public static string Scheme => DefaultScheme;
    public string AuthenticationType = DefaultScheme;
}
