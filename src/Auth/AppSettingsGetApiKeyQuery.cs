using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Clear.CloudPlatform.Auth;

public class AppSettingsGetApiKeyQuery : IGetApiKeyQuery
{
    private readonly IDictionary<string, ApiKey> _apiKeys;
    public AuthenticationSettings AuthenticationSettings { get; set; }

    public AppSettingsGetApiKeyQuery(IOptions<AuthenticationSettings> authenticationSettings)
    {
        AuthenticationSettings = authenticationSettings.Value;
        _apiKeys = AuthenticationSettings.ApiKeys.ToDictionary(x => x.Key, x => x);
    }

    public Task<ApiKey> Execute(string providedApiKey)
    {
        _apiKeys.TryGetValue(providedApiKey, out var key);
        return Task.FromResult(key);
    }
}
