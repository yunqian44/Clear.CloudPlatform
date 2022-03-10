using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clear.CloudPlatform.Auth;

public class AuthenticationSettings
{
    public string Provider { get; set; }

    public IReadOnlyCollection<ApiKey> ApiKeys { get; set; }

    public AuthenticationSettings()
    {
        Provider = "AzureAD";
    }
}
